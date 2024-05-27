using AutoMapper;
using DMBD.Kernel.DTOs;
using DMBD.Kernel.Model;
using DMBD.Kernel.Service;
using DMBD.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DMBD_App.Controllers
{
	public class SubjectController : Controller
	{

		private readonly IService<Subject> _services;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public SubjectController(IService<Subject> services, IMapper mapper, AppDbContext context)
		{
			_services = services;
			_mapper = mapper;
			_context = context;
		}

		public async Task<IActionResult> Subject()
		{
			TempData["SuccessMessage"] = "Kaydetme İşlemi başarılı!";

			//Subject Repos cekmek icin
			var subjects = await _context.SubjectRepos.ToListAsync();
			ViewBag.Subjects = subjects;
			var tcNo = HttpContext.Session.GetString("TcNo");
			//var tcNo = TempData["TcNo"] as string;
			ViewBag.TcNo = tcNo;

			//Subject listi cagirmak icin
			var subjectList = await _context.Subjects.Where(s => s.TcNo == tcNo).ToListAsync();
			ViewBag.SubjectList = subjectList;

			return View();
		}

		public async Task<IActionResult> GetSubject(Subject model)
		{
			//TempData["SuccessMessage"] = "Kaydetme İşlemi başarılı!";

			//Subject Repos cekmek icin
			var subjects = await _context.SubjectRepos.ToListAsync();
			ViewBag.Subjects = subjects; 

			//Eklenen bilgileri gorebilmek icin.

			var tcNo = HttpContext.Session.GetString("TcNo");
			ViewBag.TcNo = tcNo;
			var subjectList = await _context.Subjects.Where(s => s.TcNo == tcNo).ToListAsync();
			ViewBag.SubjectList = subjectList;
			return View("~/Views/Subject/Subject.cshtml");
		}

		public async Task<IActionResult> Save()
		{
			var subjects = await _services.GetAllAsync();

			var subjectDto = _mapper.Map<List<SubjectDto>>(subjects.ToList());

			ViewBag.subjects = new SelectList(subjectDto, "Id", "Name");

			return View(subjectDto);
		}


		/// <summary>
		/// Create post
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Create(SubjectDto model)
		{
			if (ModelState.IsValid)
			{
				var subject = new Subject
				{
					SubjectName = model.SubjectName,
					SubjectCredit = model.SubjectCredit,
					SubjectAkts = model.SubjectAkts
				};

				_context.Subjects.Add(subject);
				await _context.SaveChangesAsync();

				TempData["SuccessMessage"] = "Ders başarıyla eklendi!";
				return RedirectToAction(nameof(Index));
			}

			var subjects = _context.Subjects
		.Select(s => new SubjectDto
		{
			SubjectName = s.SubjectName,
			SubjectCredit = s.SubjectCredit,
			SubjectAkts = s.SubjectAkts,
		}).ToList();

			ViewBag.Subjects = new SelectList(subjects, "SubjectName", "SubjectName", model.SubjectName);

			return View(model);
		}
		/// <summary>
		/// Save post
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Save(SubjectDto model)
		{
			if (!string.IsNullOrEmpty(model.ExemptSubjectName))
			{
				var exemptSubject = await _context.SubjectRepos.FirstOrDefaultAsync(s => s.SubjectName == model.ExemptSubjectName);
				if (exemptSubject != null)
				{
					model.CreatedDate = DateTime.Now;
					model.ExemptSubjectId = exemptSubject.SubjectCode;
					model.ExemptSubjectName = exemptSubject.SubjectName;
					model.ExemptSubjectAkts = exemptSubject.Akts;
					model.ExemptSubjectCredit = exemptSubject.Credit;

					await _services.AddAsync(_mapper.Map<Subject>(model));
					await _context.SaveChangesAsync();
					TempData["SuccessMessage"] = "Ders başarıyla eklendi!";
					return RedirectToAction("GetSubject", "Subject");
				}
			}

			var subjects = await _context.SubjectRepos.ToListAsync();
			ViewBag.Subjects = subjects;
			return View("Index", model);
		}

		[HttpGet] // GET olarak değiştirildi
		public async Task<IActionResult> SubjectList()
		{
			var subjects = await _services.GetAllAsync();
			ViewBag.Subjects = subjects;
			return View("~/Views/Subject/Subject.cshtml");
		}

		[ServiceFilter(typeof(NotFoundFilter<Subject>))]
		public async Task<IActionResult> Update(int id)
		{
			var subject = await _services.GetByIdAsync(id);


			var subjects = await _services.GetAllAsync();

			var subjectsDto = _mapper.Map<List<SubjectDto>>(subjects.ToList());

			ViewBag.subjects = new SelectList(subjectsDto, "Id", "Name", subject.SubjectId);

			return View(_mapper.Map<SubjectDto>(subject));

		}
		[HttpPost]
		public async Task<IActionResult> Update(SubjectDto subjectDto)
		{
			if (ModelState.IsValid)
			{
				await _services.UpdateAsync(_mapper.Map<Subject>(subjectDto));
				return RedirectToAction(nameof(Index));
			}

			var subjects = await _services.GetAllAsync();

			var subjectsDto = _mapper.Map<List<SubjectDto>>(subjects.ToList());

			ViewBag.subjects = new SelectList(subjectsDto, "Id", "Name", subjectDto.SubjectId);

			return View(subjectDto);

		}

		public async Task<IActionResult> PrintToPdf()
		{
			
			var tcNo = HttpContext.Session.GetString("TcNo");
			ViewBag.TcNo = tcNo;
			ViewBag.Name = HttpContext.Session.GetString("Name");
			ViewBag.Surname = HttpContext.Session.GetString("Surname");
			ViewBag.StudentNo = HttpContext.Session.GetString("StudentNo");
			ViewBag.PhoneNumber = HttpContext.Session.GetString("PhoneNumber");
			ViewBag.MailAddress = HttpContext.Session.GetString("MailAddress");
			ViewBag.RegisterType = HttpContext.Session.GetString("RegisterType");

			var subjectList = await _context.Subjects.Where(s => s.TcNo == tcNo).ToListAsync();
			ViewBag.SubjectList = subjectList;
			return RedirectToAction("PdfScreen","PdfScreen");
		}


		public async Task<IActionResult> Remove(int id)
		{
			
			var subject = await _services.GetByIdAsync(id);
			await _services.RemoveAsync(subject);
			TempData["SuccessMessage"] = "Ders başarıyla Silindi!";
			return RedirectToAction("GetSubject","Subject");
		}
	}
}

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

		public Task<IActionResult> Create()
		{
			var subjects = _context.SubjectRepos
				.Select(s => new SubjectDto
				{
					SubjectName = s.SubjectName,
					SubjectCredit = s.Credit,
					SubjectAkts = s.Akts
				}).ToList();

			ViewBag.Subjects = new SelectList(subjects, "SubjectName", "SubjectNam e");

			return View(ViewBag.Subject);
		}

		public async Task<IActionResult> Index()
		{
			var subjects = await _context.SubjectRepos.ToListAsync();
			ViewBag.Subjects = subjects;
			return View();
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
					SubjectAkts = s.SubjectAkts
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

			var subjects = await _context.SubjectRepos.ToListAsync();
			ViewBag.Subjects = subjects;
			return View("Index", model);
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


		public async Task<IActionResult> Remove(int id)
		{
			var subject = await _services.GetByIdAsync(id);


			await _services.RemoveAsync(subject);

			return RedirectToAction(nameof(Index));
		}
	}
}

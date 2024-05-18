using AutoMapper;
using DMBD.Kernel.DTOs;
using DMBD.Kernel.Model;
using DMBD.Kernel.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMBD_App.Controllers
{
	public class SubjectController : Controller
	{

		private readonly IService<Subject> _services;

		private readonly IMapper _mapper;


		public SubjectController(IService<Subject> services,IMapper mapper)
		{
			_services = services;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{			
			return View("~/Views/Home/Index.cshtml");
		}

		public async Task<IActionResult> Save()
		{
			var subjects = await _services.GetAllAsync();

			var subjectDto = _mapper.Map<List<SubjectDto>>(subjects.ToList());

			ViewBag.subjects = new SelectList(subjectDto, "Id", "TcNo");

			return View(subjectDto);
		}

		[HttpPost]
		public async Task<IActionResult> Save(SubjectDto subjectDto)
		{
			if (ModelState.IsValid)
			{
				await _services.AddAsync(_mapper.Map<Subject>(subjectDto));
				return RedirectToAction(nameof(Index));
			}
			 
			var subjects = await _services.GetAllAsync();

			var subjectsDto = _mapper.Map<List<SubjectDto>>(subjects.ToList());

			ViewBag.subjects = new SelectList(subjectsDto, "Id", "Name");
			return View(subjectDto);
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

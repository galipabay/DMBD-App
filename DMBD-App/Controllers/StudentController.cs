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
	public class StudentController : Controller
	{

		private readonly IService<Student> _services;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public StudentController(IService<Student> services, IMapper mapper, AppDbContext context)
		{
			_services = services;
			_mapper = mapper;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
            //var subjectRepos = await _context.SubjectRepos.ToListAsync();

            //var subjects = _context.SubjectRepos
            //    .Select(s => new SubjectDto
            //    {
            //        SubjectName = s.SubjectName,
            //        SubjectCredit = s.Credit,
            //        SubjectAkts = s.Akts
            //    }).ToList();
            return RedirectToAction("Index", "Subject");
            //return View("~/Views/Subject/Subject.cshtml"/*, subjects*/);
		}

		public async Task<IActionResult> Save()
		{
			var students = await _services.GetAllAsync();

			var studentDto = _mapper.Map<List<StudentDto>>(students.ToList());

			ViewBag.students = new SelectList(studentDto, "Id", "TcNo");

			return View(studentDto);
		}

		[HttpPost]
		public async Task<IActionResult> Save(StudentDto studentDto)
		{
			if (ModelState.IsValid)
			{
				await _services.AddAsync(_mapper.Map<Student>(studentDto));
				return Redirect(nameof(Index));
			}
			 
			var students = await _services.GetAllAsync();

			var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());

			ViewBag.students = new SelectList(studentsDto, "Id", "Name");
			return View("~/Views/Home/Index.cshtml",studentDto);}

		[ServiceFilter(typeof(NotFoundFilter<Student>))]
		public async Task<IActionResult> Update(int id)
		{
			var student = await _services.GetByIdAsync(id);


			var students = await _services.GetAllAsync();

			var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());

			ViewBag.students = new SelectList(studentsDto, "Id", "Name", student.StudentId);

			return View(_mapper.Map<StudentDto>(student));

		}
		[HttpPost]
		public async Task<IActionResult> Update(StudentDto studentDto)
		{
			if (ModelState.IsValid)
			{
				await _services.UpdateAsync(_mapper.Map<Student>(studentDto));
				return RedirectToAction(nameof(Index));
			}

			var students = await _services.GetAllAsync();

			var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());

			ViewBag.students = new SelectList(studentsDto, "Id", "Name", studentDto.StudentId);

			return View(studentDto);

		}


		public async Task<IActionResult> Remove(int id)
		{
			var student = await _services.GetByIdAsync(id);


			await _services.RemoveAsync(student);

			return RedirectToAction(nameof(Index));
		}
	}
}

﻿using AutoMapper;
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

		public IActionResult Index()
		{
			return RedirectToAction("Subject", "Subject");
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
			var tempData = new TempDataAttribute();
			
			if (string.IsNullOrEmpty(studentDto.StudentNo))
			{
				// StudentNo alanı boşsa, validasyon hatalarını kaldır
				ModelState.Remove("StudentNo");
			}

			if (ModelState.IsValid)
			{
				await _services.AddAsync(_mapper.Map<Student>(studentDto));
				TempData["SuccessMessage"] = "Kaydetme İşlemi başarılı!";
				return Redirect(nameof(Index));
			}

			TempData["ErrorMessage"] = "İşlem başarısız oldu!";
			var students = await _services.GetAllAsync();
			var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());
			ViewBag.students = new SelectList(studentsDto, "Id", "Name");
			return View("~/Views/Home/Index.cshtml", studentDto); }

		[ServiceFilter(typeof(NotFoundFilter<Student>))]
		public async Task<IActionResult> Update(int id)
		{
			var student = await _services.GetByIdAsync(id);


			var students = await _services.GetAllAsync();

			var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());

			ViewBag.students = new SelectList(studentsDto, "Id", "Name", student.StudentId);

			return View(_mapper.Map<StudentDto>(student));

		}

		[HttpGet]	
		public async Task<IActionResult> StudentApplicationList()
		{
            var applications = await _services.GetAllAsync();
            var applicationDtos = _mapper.Map<List<StudentDto>>(applications);
            ViewBag.Applications = applicationDtos;
            return View("~/Views/Home/StudentApplication.cshtml");
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

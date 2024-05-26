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
		private readonly IService<Department> _departmentService;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public StudentController(IService<Department> departmentServices, IService<Student> services, IMapper mapper, AppDbContext context)
		{
			_departmentService = departmentServices;
			_services = services;
			_mapper = mapper;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
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
				// Session'a verileri ekleyin
				HttpContext.Session.SetString("Name", studentDto.Name);
				HttpContext.Session.SetString("Surname", studentDto.Surname);
				HttpContext.Session.SetString("TcNo", studentDto.TcNo);
				HttpContext.Session.SetString("StudentNo", studentDto.StudentNo ?? string.Empty);
				HttpContext.Session.SetString("MailAddress", studentDto.MailAddress);
				HttpContext.Session.SetString("PhoneNumber", studentDto.PhoneNumber);
				HttpContext.Session.SetString("RegisterType", studentDto.RegisterType.ToString());
				HttpContext.Session.SetString("PreSchoolName", studentDto.PreSchoolName);
				HttpContext.Session.SetString("PreFacultyName", studentDto.PreFacultyName);
				HttpContext.Session.SetString("PreDepartmentName", studentDto.PreDepartmentName);
				HttpContext.Session.SetString("DepartmentName", studentDto.DepartmentName);
			}

			var tempData = new TempDataAttribute();

			if (string.IsNullOrEmpty(studentDto.StudentNo))
			{
				// StudentNo alanı boşsa, validasyon hatalarını kaldır
				ModelState.Remove("StudentNo");
			}

			if (ModelState.IsValid)
			{
				studentDto.CreatedDate = DateTime.Now;
				await _services.AddAsync(_mapper.Map<Student>(studentDto));
				TempData["SuccessMessage"] = "Kaydetme İşlemi başarılı!";
				TempData["TcNo"] = studentDto.TcNo;
				return RedirectToAction("Subject", "Subject");
			}

			TempData["ErrorMessage"] = "İşlem başarısız oldu!";

			//Departments icin geri yukleme alani
			var departments = await _departmentService.GetAllAsync();
			ViewBag.Departments = departments;
			var students = await _services.GetAllAsync();
			var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());
			ViewBag.students = new SelectList(studentsDto, "Id", "Name");
			return View("~/Views/Home/Index.cshtml", studentDto);
		}


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

		[HttpGet]
		public async Task<IActionResult> GetDepartments()
		{
			var departments = await _departmentService.GetAllAsync();
			ViewBag.Departments = departments;
			return View("~/Views/Home/Index.cshtml");
		}
		public async Task<IActionResult> Remove(int id)
		{
			var student = await _services.GetByIdAsync(id);


			await _services.RemoveAsync(student);

			return RedirectToAction(nameof(Index));
		}
	}
}

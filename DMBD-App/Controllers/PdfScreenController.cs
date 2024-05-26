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
	public class PdfScreenController : Controller
	{
		private readonly IService<Subject> _subjectServices;
		private readonly IService<Student> _services;
		private readonly IService<Department> _departmentService;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public PdfScreenController(IService<Subject> subjectServices, IService<Department> departmentServices, IService<Student> services, IMapper mapper, AppDbContext context)
		{
			_departmentService = departmentServices;
			_services = services;
			_subjectServices = subjectServices;
			_mapper = mapper;
			_context = context;
		}


		public async Task<IActionResult> PdfScreen()
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
			return View("~/Views/Home/PdfScreen.cshtml");
		}
	}
}

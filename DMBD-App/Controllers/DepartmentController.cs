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
	public class DepartmentController : Controller
	{
		private readonly IService<Department> _services;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public DepartmentController(IService<Department> services, IMapper mapper, AppDbContext context)
		{
			_services = services;
			_mapper = mapper;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

	}
}

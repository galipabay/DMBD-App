using DMBD.Kernel.DTOs;
using DMBD.Kernel.Model;
using DMBD_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DMBD_App.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return RedirectToAction("GetDepartments","Student");
		}

		public IActionResult PdfScreen()
		{
			return View();
		}
		public IActionResult AdminPanelLogin()
		{
			return View();
		}

		public IActionResult AdminPanel()
		{
			return View();
		}

		public IActionResult AddAdmin()
		{
			return View();
		}

		public IActionResult AdminList()
		{
			return View();
		}

		public IActionResult StudentApplication()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public string OpenPopup()
		{
			return "<h1> TempData</h1>";
		}

		[HttpGet]
		public PartialViewResult SomeAction()
		{
			return PartialView();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

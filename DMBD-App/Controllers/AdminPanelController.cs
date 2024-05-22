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
	public class AdminPanelController : Controller
	{

		private readonly IService<AdminUser> _services;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public AdminPanelController(IService<AdminUser> services, IMapper mapper, AppDbContext context)
		{
			_services = services;
			_mapper = mapper;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(AdminUser adminUser)
		{
			var user = await _services.AnyAsync(x => x.MailAddres == adminUser.MailAddres && x.Password == adminUser.Password );
			 
			if (user == false)
			{
				// Giriş başarısız, hata mesajı döndür
				ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
				return View("AdminPanelLogin", adminUser);
			}

			// Giriş başarılı, yönlendirme yap	
			return RedirectToAction("AdminPanel","Home");
		}

		//public async Task<AdminUser> AuthenticateAsync(string username, string password)
		//{
		//	// Şifreyi hashleyip karşılaştırmak daha güvenli bir yaklaşım olur
		//	var user = await _context.AdminUsers.SingleOrDefaultAsync(x => x.MailAddres == username && x.Password == password);

		//	if (user == null)
		//	{
		//		return null;
		//	}

		//	return user;
		//}
	}
}

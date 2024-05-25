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

		public IActionResult AddAdmin()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Save(AdminUser adminUser)
        {

            if (ModelState.IsValid)
            {
                await _services.AddAsync(_mapper.Map<AdminUser>(adminUser));
                return Redirect(nameof(Index));
            }
            return Redirect(nameof(Index));
        }

        [HttpGet] // GET olarak değiştirildi
        public async Task<IActionResult> AdminList()
        {
            var adminUsers = await _services.GetAllAsync();
            ViewBag.AdminUsers = adminUsers;
            return View("~/Views/Home/AdminList.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminUser adminUser)
        {
            var user = await _services.AnyAsync(x => x.MailAddres == adminUser.MailAddres && x.Password == adminUser.Password);

            if (user == false)
            {
                // Giriş başarısız, hata mesajı döndür
                TempData["ErrorMessage"] = "Login Islemi Basarisiz oldu!";
                return View("~/Views/Home/AdminPanelLogin.cshtml",adminUser);
            }

            // Giriş başarılı, yönlendirme yap	
            return RedirectToAction("AdminPanel", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var adminUser = await _services.GetByIdAsync(id);
            if (adminUser != null)
            {
                await _services.RemoveAsync(adminUser);
            }
            return RedirectToAction(nameof(AdminList));
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

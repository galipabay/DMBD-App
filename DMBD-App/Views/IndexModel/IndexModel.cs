using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DMBD_App.Views.IndexModel
{
	public class IndexModel : PageModel
	{
		[BindProperty]
		public required string TcNo { get; set; }

		public IActionResult OnPost()
		{
			HttpContext.Session.SetString("TcNo", TcNo);
			return RedirectToPage("/Subject/Subject"); // Subject sayfasına yönlendirme
		}
	}
}

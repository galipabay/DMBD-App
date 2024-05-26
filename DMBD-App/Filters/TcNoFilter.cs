using Microsoft.AspNetCore.Mvc.Filters;

namespace DMBD_App.Filters
{
	public class TcNoFilter : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			context.HttpContext.Session.SetString("TcNo", "değeriniz");
		}
	}
}

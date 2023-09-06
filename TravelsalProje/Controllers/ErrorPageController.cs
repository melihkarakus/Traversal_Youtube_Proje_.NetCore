using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code) //startup ekranında app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}"); bunu tanımlarsak burayada error404 tanımlamamız gerekiyor
		{

            return View();
        }
    }
}

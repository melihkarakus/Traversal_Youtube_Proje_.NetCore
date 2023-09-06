using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

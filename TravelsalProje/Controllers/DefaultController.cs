using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index() //ansayfayı başta oluşturmak için kullanılan yerdir default içindedir kendisi
        {
            return View();
        }
    }
}

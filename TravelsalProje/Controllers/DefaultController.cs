using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Controllers
{
    public class DefaultController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index() //ansayfayı başta oluşturmak için kullanılan yerdir default içindedir kendisi
        {
            return View();
        }
    }
}

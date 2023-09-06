using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Areas.Member.Controllers
{
    [Area("Member")] //area içinde class tanımladığımızda sayfayı açmak için etrebitü tanımlamalıyız
    [AllowAnonymous] //login işlemi daha yapılmadığı için bunu koymam lazım yoksa sayfayı açmaz
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationsDal()); //busineslayer içinde concrete klasöründe çağırdık efdal ise datalayerdan abstran içinden çağırdık 
        public IActionResult Index()
        {
            var values = destinationManager.TGetlist(); // datamızda girilen destination bilgilerini sıralamak için kullanılan method
            return View(values);
        }
    }
}

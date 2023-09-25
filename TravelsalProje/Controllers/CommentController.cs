using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TravelsalProje.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal()); //businesslayer içindeki concrete içindeki sınıftan miras alınıyor
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<PartialViewResult> AddComment()
        {
            //ViewBag.destID = id; //viewbag ile id ye gönderim yapıp bunu view içinde çağırıyoruz
            //var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.userID = values.Id;
            return PartialView();
        }
        [HttpPost] 
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()); // tanımlanan p parametresini comment sınıfımızdan çağırıyoruz
            p.CommentState = true;
            commentManager.TAdd(p);
            return RedirectToAction("Index", "Destination"); // eğer işlem doğru olursa destination yönlendirme yaparız.
        }
    }
}

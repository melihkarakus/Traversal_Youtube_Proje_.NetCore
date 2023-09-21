using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TravelsalProje.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal()); //businesslayer içindeki concrete içindeki sınıftan miras alınıyor
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id; //viewbag ile id ye gönderim yapıp bunu view içinde çağırıyoruz
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

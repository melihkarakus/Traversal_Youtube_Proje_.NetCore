using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelsalProje.ViewComponents.Comment
{
    public class _CommentList : ViewComponent //viewcomponent miras almalı ki view component işlemi yapabilesin. buranın sayfası shared içinde components yer almaktadır.
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal()); //businesslayer içinde concrete klasörün içinde manager methodundan miras almaktadır.
        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            
            ViewBag.commentcount = context.Comments.Where(x=>x.DestinationID == id).Count();
            var values = commentManager.TGetListCommentWithDestinationAndUser(id); //commentleri yani yorum yapan kişileri idye göre listelemektedir.
            return View(values);
        }

    }
}

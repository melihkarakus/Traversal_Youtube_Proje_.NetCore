using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.Comment
{
    public class _CommentList : ViewComponent //viewcomponent miras almalı ki view component işlemi yapabilesin. buranın sayfası shared içinde components yer almaktadır.
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal()); //businesslayer içinde concrete klasörün içinde manager methodundan miras almaktadır.
        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.TGetDestinationById(id); //commentleri yani yorum yapan kişileri idye göre listelemektedir.
            return View(values);
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.Default
{
    public class _Testimonial : ViewComponent //ViewComponent tarafında kullanılması için eklenmesi gereken method
	{
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal()); //businesslayer içinde concrete içindeki classlardan miras alındı.
		public IViewComponentResult Invoke()
        {
            var values = testimonialManager.TGetlist(); //testimonial sayfasındaki bizim datamızdaki sayfalar listelensin diye method kullanılmıştır.
			return View(values);
        }
    }
}

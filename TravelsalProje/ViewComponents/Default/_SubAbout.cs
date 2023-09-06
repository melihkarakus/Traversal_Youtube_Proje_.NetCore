using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.Default
{
    public class _SubAbout : ViewComponent //ViewComponent tarafında kullanılması için eklenmesi gereken method
	{
        SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal()); //businesslayer içinde concrete içindeki classlardan miras alındı.
		public IViewComponentResult Invoke()
        {
            var values = subAboutManager.TGetlist(); //Subabout sayfasındaki bizim datamızdaki sayfalar listelensin diye method kullanılmıştır.
            return View(values);
        }
    }
}

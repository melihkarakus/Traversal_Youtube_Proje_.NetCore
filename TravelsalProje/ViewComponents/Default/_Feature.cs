using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.Default
{
    public class _Feature : ViewComponent //ViewComponent tarafında kullanılması için eklenmesi gereken method
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal()); //businesslayer içinde concrete içindeki classlardan miras alındı.
        public IViewComponentResult Invoke()
        {
            //ViewBag.image1 = featureManager.get
            return View();
        }
    }
}

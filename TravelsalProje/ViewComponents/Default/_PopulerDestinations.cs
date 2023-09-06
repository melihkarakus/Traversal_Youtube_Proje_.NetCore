using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.Default
{
    public class _PopulerDestinations : ViewComponent //ViewComponent tarafında kullanılması için eklenmesi gereken method
	{
        DestinationManager destinationManager = new DestinationManager(new EfDestinationsDal()); //businesslayer içinde concrete içindeki classlardan miras alındı.
		public IViewComponentResult Invoke()
        {
            var values = destinationManager.TGetlist(); //destinationmanagerde destinationsları tamamını getirmek için yazılan method
            return View(values);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent //ViewComponent tarafında kullanılması için eklenmesi gereken method
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

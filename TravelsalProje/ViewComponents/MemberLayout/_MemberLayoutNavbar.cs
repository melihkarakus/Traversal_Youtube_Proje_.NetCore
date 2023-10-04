using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

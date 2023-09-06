using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.MemberDashboard
{
    public class _PlatformSetting : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

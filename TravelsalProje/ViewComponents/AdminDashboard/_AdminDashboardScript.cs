using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.AdminDashboard
{
    public class _AdminDashboardScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.ViewComponents.MemberDashboard
{
    public class _MemberStatistic : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

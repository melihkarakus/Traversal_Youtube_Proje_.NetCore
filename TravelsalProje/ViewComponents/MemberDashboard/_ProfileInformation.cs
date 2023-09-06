using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TravelsalProje.ViewComponents.MemberDashboard
{
    public class _ProfileInformation : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); //usermanager datadaki bilgileri getirdik.
            ViewBag.membername = values.UserName + " " + values.Surname; //datadaki aspnetuser içindeki bilgileri getirdik 
            ViewBag.memberphone = values.PhoneNumber;
            ViewBag.membermail = values.Email;
            return View();
        }
    }
}

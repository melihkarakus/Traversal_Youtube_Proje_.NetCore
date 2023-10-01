using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TravelsalProje.Areas.Admin.Models;

namespace TravelsalProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [Route("AddRole")]
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [Route("AddRole")]
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            AppRole role = new AppRole()
            {
                Name = model.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }
            else
            {
                return View(model);
            }
        }
    }
}

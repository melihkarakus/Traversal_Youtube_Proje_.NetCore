using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TravelsalProje.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        GuideManager guideManager = new GuideManager(new EfGuideDal()); //businesslayer içindeki guidemanager içndeki tgetlist method tanımlandı ve gerekli işlemler burada çağırıldı.
        public IViewComponentResult Invoke()
        {
            var values = guideManager.TGetlist(); //guidemanagerdaki datadaki guide bilgileri listeleyip bize getirir.
            return View(values);
        }
    }
}

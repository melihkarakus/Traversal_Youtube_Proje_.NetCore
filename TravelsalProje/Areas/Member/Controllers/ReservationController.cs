using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelsalProje.Areas.Member.Controllers
{
    [Area("Member")] // area içinde tanımlanan controllerda bu etrebütü eklenmesi gerekmektedir. yoksa hata vermektedir.
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationsDal()); //destination verileri datadan çağırmak için kullanılıyor

        ReservationManager reservationManager = new ReservationManager(new EfReservationDal()); //reservation verileri datadan çağırmak için kullanılıyor

        private readonly UserManager<AppUser> _userManager; //identity usermanager içindeki userların isimleriyle getirmek için ve onları bilgilerini yaptıklarını getirmek için kullanıyoruz

		public ReservationController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByWaitAccepted(values.Id); //dataacceslayer içinde tanımlanan efreservationdal içine
                                                                                                 //yazılan ve aynısı datamızda tutuşan aktif rezervasyonları bize view içinde vermesi için bize datamızdaki verileri getirmesi için yapılan kodlama
            return View(valueslist);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByWaitPrevios(values.Id);
            return View(valueslist);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByWaitApproval(values.Id); //hem view içinde ki city çağırmak için hemde statu durumunu belirtip getirmek için
                                                                                                 //çağırdığımız method getlistwith olan ilk başta dataacceslayer dan sonra businesslayer içindeki abstractlardan aldık gidişatı izleyebilirsin kolay yaparsın

            return View(valuesList);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetlist() //listeden seçim yapmak için selecitem kullanılır. bunu from içinde yukarda çağırlan destination içinde listelemek içinde parantez içine getlist ile tanımlanır.
                                           select new SelectListItem
                                           {
                                               Text = x.City, // city listelemek için getirildi view içinde görüntüleyebilirsin yani web içinde 
                                               Value= x.DestinationsID.ToString()
                                           }).ToList();
            ViewBag.v = values;// viewbag ise values içine tanımlanı viewbag de tutup bunu view içindeki web içine çağırılır.
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p) //resrvation database deki sütunu getirmek için p parametresine attık 
        {
            p.AppUserId = 9; // burada id şekilde statik tuttuk sonra dinamik yapılacak
            p.Status = "Onay Bekliyor";
            reservationManager.TAdd(p); // p parametresini reservationmanager çağırıp p parametesine ekledik.
            return RedirectToAction("MyCurrentReservation");
        }
        public IActionResult Deneme()
        {
            return View();
        }
    }
}

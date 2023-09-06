using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Areas.Admin.Controllers
{
	[Area("Admin")] // area vermezsem area ile çalıştığımızı sayfa göremez
	[Route("Admin/Guide")] // burada admin guide çağırmalıyız ki sayafalara erişelim
	public class GuideController : Controller
	{
		private readonly IGuideService _guideService;

		public GuideController(IGuideService guideService)
		{
			_guideService = guideService;
		}
		[Route("")] // boş bir route atamalıyız
        [Route("Index")] // ındexe gitmek için yine admini çağırmamıza gerek yok zaten yukarıda admin çağırıyoruz
        public IActionResult Index() // GuideIndex de önemli bir yer vardır oda pasif veya aktif yap butonu çok önemli oraya bakabilirsin
		{
			var values = _guideService.TGetlist();
			return View(values);
		}
        [Route("GuideDelete/{id}")] // eğerki id ile bir işlem yapılması gerekiyor ise id ile route döndürmemiz gerekiyor
        public IActionResult GuideDelete(int id)
		{
			var values = _guideService.TGetByID(id);
			_guideService.TDelete(values);
			return RedirectToAction("Index");
		}
        [Route("AddGuide")] //admin çağırmamıza gerek yok direk addguide zaten admin ve indexin içinde olduğu için
        [HttpGet]
        public IActionResult AddGuide()
		{
			return View();
		}
        [Route("AddGuide")] // Http post içinde tanımlanmalı
        [HttpPost]
		public IActionResult AddGuide(Guide guide)
		{
			GuideValidator validationRules = new GuideValidator(); //guidevalidotru burada çağırdık çünkü hatalar çıkması gerekiyor
			ValidationResult validationResult = validationRules.Validate(guide); //validation result oluşturduk hangi yerlerde hata çıkması için kullanıldı
			if (validationResult.IsValid) //eğer kullanıcının girdiği verilerde hata yok ise oluşturucak
			{
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
			else
			{
				foreach (var item in validationResult.Errors) // eğer kullanıcının girdiği verilerde hata var ise bize guidevalidator içinde hata mesajlarını döndürücek
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
			
		}
		[Route("EditGuide")]//admin çağırmamıza gerek yok direk addguide zaten admin ve indexin içinde olduğu için
        [HttpGet]
		public IActionResult EditGuide(int id) 
		{
			var values = _guideService.TGetByID(id);
			return View(values);
		}
        [Route("EditGuide")]
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
		[Route("ChangeToTrue/{id}")]//id ye göre route verdik pasif aktif bastığımda aynı sayfada kalıp işlem yapması için 
        public IActionResult ChangeToTrue(int id) // ilk dataaccesde guide içinde metotlar var onların tanımlaması yapıldı 
		{
			_guideService.TChangeToTrueByGuide(id); // dataacces içindeki verilerin imzaları businessda çağırıldı yeni veri olarak indexde işlem uygulandı
			return RedirectToAction("index","Guide", new {area = "Admin"});
		}
        [Route("ChangeToFalse/{id}")] //id ye göre route verdik pasif aktif bastığımda aynı sayfada kalıp işlem yapması için 
        public IActionResult ChangeToFalse(int id)
        {
			_guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("index", "Guide", new { area = "Admin" }); //burada işlem yapılınca sayfadad kalması için 
        }
    }
}

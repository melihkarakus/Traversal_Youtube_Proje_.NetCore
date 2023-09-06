using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationsService _destinationsService;

        public DestinationController(IDestinationsService destinationsService)
        {
            _destinationsService = destinationsService;
        }

        public IActionResult Index()
        {
            var values = _destinationsService.TGetlist(); //database deki destination içindeki bilgileri getirmek için kullandık
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destinations destinations)
        {
            _destinationsService.TAdd(destinations);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationsService.TGetByID(id);
            _destinationsService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationsService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destinations destinations)
        {
            _destinationsService.TUpdate(destinations);
            return RedirectToAction("Index");
        }
    }
}

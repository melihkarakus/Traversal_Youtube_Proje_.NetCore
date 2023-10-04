using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class LastDestinations : Controller
    {
        private readonly IDestinationsService _destinationsService;

        public LastDestinations(IDestinationsService destinationsService)
        {
            _destinationsService = destinationsService;
        }

        public IActionResult Index()
        {
            var values = _destinationsService.TGetLast4Destinations();
            return View(values);
        }
    }
}

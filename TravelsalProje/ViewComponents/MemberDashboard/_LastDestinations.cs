using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace TravelsalProje.ViewComponents.MemberDashboard
{
    public class _LastDestinations : ViewComponent
    {
        private readonly IDestinationsService _destinationsService;

        public _LastDestinations(IDestinationsService destinationsService)
        {
            _destinationsService = destinationsService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationsService.TGetLast4Destinations();
            return View(values);
        }
    }
}

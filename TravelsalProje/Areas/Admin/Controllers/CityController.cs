using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TravelsalProje.Models;

namespace TravelsalProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationsService _destinationsService;
        public CityController(IDestinationsService destinationsService)
        {
            _destinationsService = destinationsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsoncity = JsonConvert.SerializeObject(_destinationsService.TGetlist());
            return Json(jsoncity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destinations destination) // entitlayer destinations dan veri aldık
        {
            destination.Status = true;
            _destinationsService.TAdd(destination); // eklencek veriler destinations entitlayerden gelicek
            var values = JsonConvert.SerializeObject(destination); // json olarak çevir
            return Json(values); // ve ekrana yazdır
        }

        public IActionResult GetById(int DestinationsID)//ajaxda script için getbyıd olan ajaxda tanımlama bu şekilde yapılmalı
        {
            var values = _destinationsService.TGetByID(DestinationsID); //destinationıd göre listeleme yapıyoruz id ye göre yani
            var JsonValues = JsonConvert.SerializeObject(values); //bunu ajax veya bir deyimle json çeviriyoruz
            return Json(JsonValues);//json olarak döndürüyoruz
        }

        public IActionResult DeleteCityDestination(int id)
        {
            var values = _destinationsService.TGetByID(id);
            _destinationsService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCityDestination(Destinations destinations)
        {
            _destinationsService.TUpdate(destinations);
            var v = JsonConvert.SerializeObject(destinations);
            return Json(v);
        }
        //public static List<CityModel> cities = new List<CityModel> //citymodelden nesneler üretip bunu static halde alt tarafta çağırdık
        //{
        //    new CityModel //citymodel çağırdık
        //    {//Verileri her biri içine girdik
        //        CityID = 1,
        //        CityName = "İstanbul",
        //        CityCountry = "Gaziosmanpaşa",
        //    },
        //    new CityModel
        //    {
        //        CityID = 2,
        //        CityName = "Roma",
        //        CityCountry = "İtalya",
        //    },
        //    new CityModel
        //    {
        //        CityID = 3,
        //        CityName = "Londra",
        //        CityCountry = "İngiltere"
        //    }
        //}; 

        
    }
}

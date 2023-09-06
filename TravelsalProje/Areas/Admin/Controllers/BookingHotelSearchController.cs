using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using TravelsalProje.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelsalProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?room_number=1&dest_type=city&order_by=popularity&dest_id=-1456928&locale=en-gb&checkin_date=2023-01-27&filter_by_currency=EUR&checkout_date=2023-01-28&adults_number=2&units=metric&children_ages=5%2C0&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_number=2"),
                Headers =
    {
        { "X-RapidAPI-Key", "58e621d680msh2f5df1473676306p1efb2ejsn1d47b59a39b7" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);
                return View(values.result);
            }
        }

    //    [HttpGet]
    //    public IActionResult GetCityDestID()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> GetCityDestID(string p)
    //    {
    //        var client = new HttpClient();
    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
    //            Headers =
    //{
    //    { "X-RapidAPI-Key", "58e621d680msh2f5df1473676306p1efb2ejsn1d47b59a39b7" },
    //    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    //},
    //        };
    //        using (var response = await client.SendAsync(request))
    //        {
    //            response.EnsureSuccessStatusCode();
    //            var body = await response.Content.ReadAsStringAsync();

    //            return View();
    //        }
    //    }
    }
}

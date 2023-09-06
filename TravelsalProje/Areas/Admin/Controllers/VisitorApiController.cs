using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelsalProje.Areas.Admin.Models;

namespace TravelsalProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //httpclient kullanarak bir nesne ürettik

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() //async task oolması gerekiyor bunun 
        {
            var client = _httpClientFactory.CreateClient();//httpclientten bir client oluşturduk
            var responsMessage = await client.GetAsync("http://localhost:60648/api/Visitor"); //response message yerine swagger daki get içindeki uzatıyı aldık
            if (responsMessage.IsSuccessStatusCode)//response message eğer doğruysa 
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();//response mesaıjn içindeki oku
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData); // jsonda datanın içindeki verileri jsonconverte çevir
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);//yukarda tanımlanan model için json converte serialaz olarak çevirdik
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json"); //string olarak çevirdik ve parantez için verileri girdik
            var responsMessage = await client.PostAsync("http://localhost:60648/api/Visitor", content); //swagger içindeki url ve content ekledik
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:60648/api/Visitor/{id}");//id şeklinde silinmesi için bu işlemi yaptık
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:60648/api/Visitor/{id}");//id şeklinde güncellenmesş için bu şekilde tanımladık
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//responsemessage content içine okuması için bu method 
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);//veriler json data içinden karşımıza geldi
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:60648/api/Visitor/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

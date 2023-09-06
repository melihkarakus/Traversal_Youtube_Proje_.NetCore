using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TravelsalProje.Models;

namespace TravelsalProje.Controllers
{
    public class ExcelController : Controller //excel raporlarını oluşturmak için bir excel controller oluşturduk
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index() //excel controllera bir index oluşturduk
        {
            return View();
        }
        public List<DestinationModel> DestinationList() //list modülünde bir sınıf oluşturduk aslında
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>(); //model içinde bizim tanımladıklarımızla veri tabanın tanımladıkları bir olsun diye model tanımlandı
            using (var c = new Context())//database buraya çağırdık içindeki verilere ulaşmak için
            {
                //destinationmodel ile bizim databasedeki destinationsları birbirlerine eşitledik bunuda ekrana yansıttık
                destinationModels = c.Destinations.Select(x => new DestinationModel 
                {
                    City = x.City, //modelde tanımlanan city ve databasede olan city eşit dedik
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity,
                }).ToList();
            }
            return destinationModels; //buradada destination model getirdik
        }
        public IActionResult DestinationExcelReport() //bir sınıf daha oluşturduk
        {
            using (var workBook = new XLWorkbook())//excel için tanımlanan bir workbook 
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi"); //excel aşağıda çalışma sayfasının ismini belirliyor
                workSheet.Cell(1, 1).Value = "Şehir"; //çalışma sayfasında colum değerleri belirliyoruz
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";


                int rowCount = 2; // 2 den başlanması için sıraya sokuyoruz
                foreach (var item in DestinationList()) //yukarda tanımlanan sınıfı burada çağırdık
                {
                    workSheet.Cell(rowCount,1).Value = item.City; //columun 1 değerine databasedeki veriler gelicek
                    workSheet.Cell(rowCount,2).Value = item.DayNight;
                    workSheet.Cell(rowCount,3).Value = item.Price;
                    workSheet.Cell(rowCount,4).Value = item.Capacity;
                    rowCount++;
                }
                using (var stream = new MemoryStream()) //bunu excel indirmek için kullanılan başlık methodu
                {
                    workBook.SaveAs(stream); //işlem yapıldığında onu kaydetmesi
                    var content = stream.ToArray(); //bunu stream ile döndürdük
                    // return file ile de bir lokasyon oluşturduk excel formatında indirmesi için sonrasında ona bir isim verdik
                    return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
        public IActionResult StaticExcelReport() //burasıda bizim istediğimiz formatta çekiyor verileri
        {
            //ExcelPackage excel = new ExcelPackage(); //excel page ekliyoruz
            //var worksheet = excel.Workbook.Worksheets.Add("Sayfa 1"); //excel isim veriyoruz
            //worksheet.Cells[1, 1].Value = "Rota";//kendi elimizle buraya colum isim veriyoruz
            //worksheet.Cells[1, 2].Value = "Rehber";
            //worksheet.Cells[1, 3].Value = "Kontejyan";

            //worksheet.Cells[2, 1].Value = "Gurcistan Batum Turu";//kendi elimizle burada kimi olmasını belirliyoruz hangi değerin olmasını
            //worksheet.Cells[2, 2].Value = "Sude Bayrak";
            //worksheet.Cells[2, 3].Value = "1";

            //worksheet.Cells[3, 1].Value = "Londra Turu";
            //worksheet.Cells[3, 2].Value = "Nur Kavran";
            //worksheet.Cells[3, 3].Value = "1";

            //var bytes = excel.GetAsByteArray(); //bytes şeklinde dönüştürüp
            //// aşağıda excel formatında indirilmesi ve lokasyanı vermesi için çağırıyoruz
            //return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya2.xlsx");

            //burada fazla koddan kaçınıp business kısmına tanımlamalar yaptık 
            return File(_excelService.ExcelList(DestinationList()),"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
        }
    }
}

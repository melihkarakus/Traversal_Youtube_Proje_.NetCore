using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace TravelsalProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPDFReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");//programda pdf nerde tutucağımızı belirledik
            var stream = new FileStream(path, FileMode.Create);//pdf oluşturduk
            Document document = new Document(PageSize.A4); // pdf hangi şekilde olcağı belirleniyor.
            PdfWriter.GetInstance(document, stream); //pdf dosyası oluşturmaya yarıyor.
            document.Open(); // pdf açtık
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon PDF Raporu"); //burada istediğimiz paragraf ismini verdik.
            document.Add(paragraph);//paragrafı dökümana ekleme işlemi yapıyoruz.
            document.Close();//dökümanı kapattık
            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);//burada tablonun kaç sutun veya içeriğini düzenlemeye yarıyor.
            pdfPTable.AddCell("Misafir Adı"); // sütunlara başlık veriyoruz.
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Sude");//başlıkların sütunlarını doldurduk
            pdfPTable.AddCell("Bayrak");
            pdfPTable.AddCell("23456788901");

            pdfPTable.AddCell("Melih");//başlıkların sütunlarını doldurduk
            pdfPTable.AddCell("Karakuş");
            pdfPTable.AddCell("23456788901");

            document.Add(pdfPTable); //tanımlanan pdf tablosunu eklenemezsek bu şekilde çalışmaz
            document.Close();
            return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}

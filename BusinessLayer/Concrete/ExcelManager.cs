using BusinessLayer.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {

        public byte[] ExcelList<T>(List<T> t) where T : class
        {
            ExcelPackage excelPackage = new ExcelPackage(); // burada excel içinde bir nesne oluşturduk
            var workSheet = excelPackage.Workbook.Worksheets.Add("sayfa1.xsls"); //excel için bir sayfa oluşturuldu burda
            workSheet.Cells["A1"].LoadFromCollection(t, true, OfficeOpenXml.Table.TableStyles.Light10); // Burada sayfamızın tasarımını yapıyoruz
            return excelPackage.GetAsByteArray();
        }
    }
}

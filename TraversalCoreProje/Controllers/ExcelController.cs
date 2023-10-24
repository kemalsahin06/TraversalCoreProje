using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.CityName,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }


        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheed = excel.Workbook.Worksheets.Add("Sayfa1");
            workSheed.Cells[1, 1].Value = "Rota";
            workSheed.Cells[1, 2].Value = "Rehber";
            workSheed.Cells[1, 3].Value = "Kontenjan";

            workSheed.Cells[2, 1].Value = "Gürcistan Batum Turu";
            workSheed.Cells[2, 2].Value = "Kemal Şahin";
            workSheed.Cells[2, 3].Value = "40";

            workSheed.Cells[3, 1].Value = "Akdeniz Turu";
            workSheed.Cells[3, 2].Value = "Laz Kopat";
            workSheed.Cells[3, 3].Value = "37";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya2.xlsl");
        }






        public IActionResult DestinationExcelRepor()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var workBook = new XLWorkbook()) // bunun  paketini indirdim
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Sehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;

                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;

                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }

            }

        }
    }
}

using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection.Metadata;
using Document = iTextSharp.text.Document;
using Paragraph = iTextSharp.text.Paragraph;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/"+"dosya1.pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(iTextSharp.text.PageSize.A4);
            PdfWriter.GetInstance(document,stream);
            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervation Pdf Raporu");

            document.Add(paragraph);
            document.Close();
            return File("/PdfReport/Dosya1.pdf","application/pdf","dosya1.pdf");
        }



        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya2.pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(iTextSharp.text.PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            PdfPTable pdfTable = new PdfPTable(3); // sutun sayısı bak bunun ismine dikkat et

            pdfTable.AddCell("Misafir Adı");
            pdfTable.AddCell("Misafir Soyadı");
            pdfTable.AddCell("Misafir Tc");

            pdfTable.AddCell("Kemal");
            pdfTable.AddCell("Şahin");
            pdfTable.AddCell("12345678910");

            pdfTable.AddCell("Mehmet");
            pdfTable.AddCell("Yılmaz");
            pdfTable.AddCell("22222222222");

            pdfTable.AddCell("Ezel");
            pdfTable.AddCell("Işıl");
            pdfTable.AddCell("33333333333");

            document.Add(pdfTable);
            document.Close();
            return File("/PdfReport/Dosya2.pdf", "application/pdf", "dosya2.pdf");
        }


    }  
}

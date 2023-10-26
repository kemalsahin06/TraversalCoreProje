using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            List< Announcement> announcements = _announcementService.TGetList();
            List<AnnouncementListModel> model = new List<AnnouncementListModel>();

            foreach (var item in announcements)
            {
                AnnouncementListModel announcementListModel = new AnnouncementListModel();
                announcementListModel.ID = item.AnnouncementID;
                announcementListModel.Title = item.Title;
                announcementListModel.Content = item.Content;

                model.Add(announcementListModel);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(string x)
        {
            return View();
        }
    }
}

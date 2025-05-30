﻿using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")] // burda aşşagıdaki yönlendirme işleminde bunu yazmadan diger sayfalara geçiş saglamadı
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {


            GuideValidator validationRules = new GuideValidator(); // burda kullanıcıdan girdiklerini düzeltmek için yapıyoruz
            ValidationResult result = validationRules.Validate(guide);

            if (result.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();  
            }
        }


        [Route("EditGuide")]
        [HttpGet]
        public ActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }

        [Route("EditGuide")]
        [HttpPost]
        public ActionResult EditGuide(Guide guide)
        {
           
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }


        [Route("ChangeToTrue/{id}")] // burdada yönlendirm için kullandım önemliyoksa çalışmıyo
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index","Guide",new {area="Admin"});
        }


        [Route("ChangeToFalse/{id}")] // bunlar onemli yönlendirme için
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" }); // yönlendirme için önemli
        }
    }
}

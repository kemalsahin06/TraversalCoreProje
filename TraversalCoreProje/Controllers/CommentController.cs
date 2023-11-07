using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.destID = id;
            return PartialView();
        }
        [HttpPost]
        // action isimlerine dikkat et burda baska sayfaya gitmek için
        public IActionResult AddComment(Comment p)
        {
            p.CommenDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
           
            cm.TAdd(p);
           
            return RedirectToAction("Index","Destination");
        }
    }
}

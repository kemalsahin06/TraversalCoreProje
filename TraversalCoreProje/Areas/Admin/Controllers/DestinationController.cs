using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = dm.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            dm.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = dm.TGetByID(id);
            dm.TDelete(values); // direk id ye göre silemiyoruz
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = dm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            dm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        AppUserManager aum = new AppUserManager(new EfAppUserDal());

        RezervationManager rm = new RezervationManager(new EfRezervationDal());
        public IActionResult Index()
        {
            var values = aum.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = aum.TGetByID(id);
            aum.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = aum.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser p)
        {
            aum.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            aum.TGetList();
            return View();
        }
        public IActionResult ReservationUser(int id)
        {
            var values = rm.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}

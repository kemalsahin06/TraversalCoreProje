using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class RezervationController : Controller
    {
        DestinationManager desm = new DestinationManager(new EfDestinationDal());
        RezervationManager rm = new RezervationManager(new EfRezervationDal());
        public readonly UserManager<AppUser> _userManager;

        public RezervationController(UserManager<AppUser> userManager )
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuestList = rm.GetListWithReservationByAccepted(values.Id);
            return View(valuestList);
        }

        public async Task<IActionResult> MyOldRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuestList = rm.GetListWithReservationByPrevious(values.Id);
            return View(valuestList);
        }

        public async Task<IActionResult> MyApprovalRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuestList = rm.GetListWithReservationByWaitAprroval(values.Id);
            return View(valuestList);
        }


            [HttpGet]
        public IActionResult NewRezervation()
        {
            // bunu drap davun olarak göstermek içim böyle yaptık
            List<SelectListItem> values = (from x in desm.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CityName,
                                               Value = x.DestinationID.ToString(),
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewRezervation(Rezervation p)
        {
            p.AppUserId = 3;
            p.ReservationStatus = "Onay Bekliyor";
            rm.TAdd(p);
            return RedirectToAction("MyCurrentRezervation");
        }


        public IActionResult Deneme()
        {
            return View();
        }
    }
}

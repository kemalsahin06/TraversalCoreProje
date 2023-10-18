using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _Carts1Statistic : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Users.Count();
            return View();
        }
    }
}

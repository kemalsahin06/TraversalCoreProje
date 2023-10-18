using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class AdminDashboardHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

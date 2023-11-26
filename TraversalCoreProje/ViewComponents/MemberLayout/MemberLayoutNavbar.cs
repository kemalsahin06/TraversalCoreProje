using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberLayout
{
    public class MemberLayoutNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

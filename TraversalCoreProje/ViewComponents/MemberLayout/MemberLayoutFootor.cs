using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberLayout
{
    public class MemberLayoutFootor : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

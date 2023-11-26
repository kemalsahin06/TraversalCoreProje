using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberLayout
{
    public class MemberLayoutSearc :  ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

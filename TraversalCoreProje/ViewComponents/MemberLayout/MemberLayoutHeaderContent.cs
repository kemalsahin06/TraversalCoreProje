using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberLayout
{
    public class MemberLayoutHeaderContent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

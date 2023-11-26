using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberDasboard
{
    public class MemberHeaderLayoutContent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

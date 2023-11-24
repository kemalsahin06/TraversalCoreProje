using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberDasboard
{
    public class _MemberStatic : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

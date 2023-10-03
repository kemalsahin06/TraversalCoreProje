using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _TestiMonial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

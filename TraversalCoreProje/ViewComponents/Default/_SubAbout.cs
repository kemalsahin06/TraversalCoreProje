using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager sm = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = sm.TGetList();
            return View(values);
        }
    }
}

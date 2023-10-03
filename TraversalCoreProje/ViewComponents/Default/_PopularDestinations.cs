using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = dm.TGetList();
            return View(values);
        }
    }
}

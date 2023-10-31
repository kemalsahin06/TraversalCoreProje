using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Cors.Handlers.DestinationHandlers;
using TraversalCoreProje.Cors.Queries.DestinationQuery;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationCQRSController : Controller
    {

        private readonly GetAllDestinationQueryHandler _queryHandler;
        private readonly GetDestinationByIDQueryHandler getDestinationByID;

        public DestinationCQRSController(GetAllDestinationQueryHandler queryHandler, GetDestinationByIDQueryHandler getDestinationByID)
        {
            _queryHandler = queryHandler;
            this.getDestinationByID = getDestinationByID;
        }

        public IActionResult Index()
        {
            var values = _queryHandler.Handle();
            return View(values);
        }

        public IActionResult GetDetDestination(int id)
        {
            var values = getDestinationByID.Handle(new GetDestinationBYIDQuery(id));
            return View(values);
        }
    }
}

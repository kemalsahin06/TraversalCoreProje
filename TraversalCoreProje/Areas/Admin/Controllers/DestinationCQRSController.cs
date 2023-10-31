using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Cors.Commands.DestinationComments;
using TraversalCoreProje.Cors.Handlers.DestinationHandlers;
using TraversalCoreProje.Cors.Queries.DestinationQuery;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    [AllowAnonymous]
    public class DestinationCQRSController : Controller
    {

        private readonly GetAllDestinationQueryHandler _queryHandler;
        private readonly GetDestinationByIDQueryHandler _getDestinationByID;
        private readonly CreateDestinationCommandHandler _createDestinationCommand;
        private readonly RemoveDestinationCommentHandle _removeDestinationComment_;
        private readonly UpdateDestinationCommentHandle _updateDestinationComment;

        public DestinationCQRSController(GetAllDestinationQueryHandler queryHandler, GetDestinationByIDQueryHandler getDestinationByID, CreateDestinationCommandHandler createDestinationCommand, RemoveDestinationCommentHandle removeDestinationComment_, UpdateDestinationCommentHandle updateDestinationComment)
        {
            _queryHandler = queryHandler;
            _getDestinationByID = getDestinationByID;
            _createDestinationCommand = createDestinationCommand;
            _removeDestinationComment_ = removeDestinationComment_;
            _updateDestinationComment = updateDestinationComment;
        }

        public IActionResult Index()
        {
            var values = _queryHandler.Handle();
            return View(values);
        }


        [HttpGet]
        public IActionResult GetDetDestination(int id)
        {
            
            var values = _getDestinationByID.Handle(new GetDestinationBYIDQuery(id));
            return View(values);
        }


        [HttpPost]
        public IActionResult GetDetDestination(UpdateDestinationComment comment)
        {

           _updateDestinationComment.Handle(comment);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationComment comment)
        {
            _createDestinationCommand.Handle(comment);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationComment_.Handle(new RemoveDestinationComment(id));
            return RedirectToAction("Index");
        }

    }
}

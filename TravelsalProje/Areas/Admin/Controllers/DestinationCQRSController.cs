using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;
using TravelsalProje.CQRS.Commands.DestinationCommands;
using TravelsalProje.CQRS.Handlers.DestinationHandler;
using TravelsalProje.CQRS.Queries.DestinationQuery;
using TravelsalProje.CQRS.Results;

namespace TravelsalProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationCQRSController : Controller // burası CQRS için tanımlanan controller
    {
        private readonly GetAllDestinationQueryHandler _destinationQueryHandler;
        private readonly GetDestinationByIDQueryHandler _destinationIDQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;
        private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
        public DestinationCQRSController(GetAllDestinationQueryHandler destinationQueryHandler, GetDestinationByIDQueryHandler destinationIDQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler)
        {
            _destinationQueryHandler = destinationQueryHandler;
            _destinationIDQueryHandler = destinationIDQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
            _getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _destinationQueryHandler.Handle();//handle çağırmış olduk burda
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}

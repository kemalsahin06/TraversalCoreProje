using DataAccessLayer.Concrete;
using System.Security.Permissions;
using TraversalCoreProje.Cors.Commands.DestinationComments;

namespace TraversalCoreProje.Cors.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommentHandle
    {
        private readonly Context _context;

        public UpdateDestinationCommentHandle(Context context)
        {
            _context = context;
        }



        public void Handle(UpdateDestinationComment update)
        {
            var values = _context.Destinations.Find(update.DestinationId);
             values.CityName = update.City;
             values.DayNight = update.DayNight;
             values.Price = update.Price;
            _context.SaveChanges();
        }

    }
}

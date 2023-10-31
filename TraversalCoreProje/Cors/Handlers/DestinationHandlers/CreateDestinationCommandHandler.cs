using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using TraversalCoreProje.Cors.Commands.DestinationComments;

namespace TraversalCoreProje.Cors.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }


        public void Handle(CreateDestinationComment comment)
        {
            _context.Destinations.Add(new Destination
            {
                CityName = comment.CityName,
                Price = comment.Price,
                DayNight = comment.DayNight,
                Capacity = comment.Capacity,
                Status = true
            });
            _context.SaveChanges();
        }
    }
}

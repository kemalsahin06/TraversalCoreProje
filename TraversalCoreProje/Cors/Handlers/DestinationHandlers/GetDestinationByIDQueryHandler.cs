using DataAccessLayer.Concrete;
using System.Drawing.Printing;
using TraversalCoreProje.Cors.Queries.DestinationQuery;
using TraversalCoreProje.Cors.Results.DestinationResults;

namespace TraversalCoreProje.Cors.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationBYIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                DestinationId = values.DestinationID,
                City = values.CityName,
                DayNight = values.DayNight,
                Price = values.Price,
            };
        }
        

    }
}

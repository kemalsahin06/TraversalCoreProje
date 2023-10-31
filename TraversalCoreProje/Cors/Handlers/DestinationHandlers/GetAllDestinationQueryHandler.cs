using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TraversalCoreProje.Cors.Queries.DestinationQuery;
using TraversalCoreProje.Cors.Results.DestinationResults;

namespace TraversalCoreProje.Cors.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {

        private readonly Context _contex;

        public GetAllDestinationQueryHandler(Context contex)
        {
            _contex = contex;
        }


        public List<GetAllDestinationQueryResult> Handle( )
        {
            var values =_contex.Destinations.Select(x=> new GetAllDestinationQueryResult
            {
                DestinationID = x.DestinationID,
                Capacity = x.Capacity,
                CityName = x.CityName,
                DayNight = x.DayNight,
                Price = x.Price,
            }).AsNoTracking().ToList();

            return values;
        }
    }
}

using DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProje.Cors.Queries.GuideQuery;
using TraversalCoreProje.Cors.Results.GuideResults;

namespace TraversalCoreProje.Cors.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandle : IRequestHandler<GetGuideByAıQuery, GetGuideByIDQUERYResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandle(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQUERYResult> Handle(GetGuideByAıQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.id);
            return new GetGuideByIDQUERYResult
            {
                GuideID = request.id,
                Description = values.Description,
                Name = values.Name,
            };
        }
    }
}

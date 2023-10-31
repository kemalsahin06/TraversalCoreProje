using MediatR;
using TraversalCoreProje.Cors.Results.GuideResults;

namespace TraversalCoreProje.Cors.Queries.GuideQuery
{
    public class GetGuideByAıQuery : IRequest<GetGuideByIDQUERYResult>
    {
        public GetGuideByAıQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}

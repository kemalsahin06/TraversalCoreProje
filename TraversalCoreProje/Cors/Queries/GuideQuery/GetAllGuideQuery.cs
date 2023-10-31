using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MediatR;
using System.Collections.Generic;
using TraversalCoreProje.Cors.Results.GuideResults;

namespace TraversalCoreProje.Cors.Queries.GuideQuery
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {
    }
}

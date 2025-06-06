﻿using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProje.Cors.Queries.GuideQuery;
using TraversalCoreProje.Cors.Results.GuideResults;

namespace TraversalCoreProje.Cors.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandle : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandle(Context context)
        {
            _context = context; 
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideID = x.GuideID,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name,

            }).AsNoTracking().ToListAsync(); // async kullandıgımız için gegişik parametreler kullanıdık
        }
    }
}

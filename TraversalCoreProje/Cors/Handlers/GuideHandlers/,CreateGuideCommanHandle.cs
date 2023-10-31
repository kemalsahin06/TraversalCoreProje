using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Wordprocessing;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProje.Cors.Commands.GuideComments;

namespace TraversalCoreProje.Cors.Handlers.GuideHandlers
{
    public class _CreateGuideCommanHandle : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public _CreateGuideCommanHandle(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new EntityLayer.Concrete.Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true,

            });
            await _context.SaveChangesAsync(); // bak dikkat burda ekleem işlemide degişik oluyo
            return Unit.Value;
        }
    }
}

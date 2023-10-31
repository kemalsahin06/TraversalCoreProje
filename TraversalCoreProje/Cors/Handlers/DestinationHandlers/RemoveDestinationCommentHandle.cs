using DataAccessLayer.Concrete;
using TraversalCoreProje.Cors.Commands.DestinationComments;

namespace TraversalCoreProje.Cors.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommentHandle
    {
        private readonly Context _context;

        public RemoveDestinationCommentHandle(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationComment comment)
        {
            var values = _context.Destinations.Find(comment.ID);
            _context.Destinations.Remove(values);
            _context.SaveChangesAsync();
        }
    }
}

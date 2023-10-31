using MediatR;

namespace TraversalCoreProje.Cors.Commands.GuideComments
{
    public class CreateGuideCommand :IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
      
       

    }
}

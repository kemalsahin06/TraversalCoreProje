using Microsoft.AspNetCore.SignalR;
using SıgnalIRApii.Model;
using System.Threading.Tasks;

namespace SıgnalIRApii.Hubs
{
    public class VisitorHub : Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitlist", _visitorService.GetVisitorChartList());
        }
    }
}

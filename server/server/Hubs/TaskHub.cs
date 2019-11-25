using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace server.Hubs
{
    public class TaskHub : Hub
    {
        public async Task RegisterTask()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "TASKID");
        }
    }
}

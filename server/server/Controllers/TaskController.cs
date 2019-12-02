using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using server.Hubs;
using System.Threading.Tasks;
using System;

namespace server.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly IHubContext<TaskHub> _hubContext;

        public TaskController(IHubContext<TaskHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task CreateTask()
        {
            for (int i = 0; i <= 100; i++)
            {
                await _hubContext.Clients.Group("TASKID").SendAsync("progress", i);
                await Task.Delay(100);
                Console.WriteLine("Error");
            }

        }
    }
}

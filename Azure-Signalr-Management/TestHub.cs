using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_Signalr_Management
{
    public class TestHub : Hub
    {
        private readonly ILogger<TestHub> _logger;

        public TestHub(ILogger<TestHub> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"Connected: {Context.ConnectionId}");
            await Groups.AddToGroupAsync(Context.ConnectionId, "testGroup").ConfigureAwait(false);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _logger.LogInformation($"Disconnected: {Context.ConnectionId}");
            return base.OnDisconnectedAsync(exception);
        }

    }
}

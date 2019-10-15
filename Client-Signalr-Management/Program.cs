using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using System;
using System.Threading.Tasks;

namespace Client_Signalr_Management
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceManager = new ServiceManagerBuilder()
            .WithOptions(option =>
            {
                option.ConnectionString = "";
            })
            .Build();

            Console.WriteLine("Press any key to connect");
            Console.ReadKey();

            var hubContext = await serviceManager.CreateHubContextAsync("TestHub").ConfigureAwait(false);

            await hubContext.Clients.Group("testGroup").SendAsync("Send", "Hello").ConfigureAwait(false);

            Console.ReadKey();
            await hubContext.DisposeAsync();
        }
    }
}

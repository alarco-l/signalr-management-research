using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/testHub")
                .Build();

            Console.WriteLine("Press any key to connect");
            Console.ReadKey();

            try
            {
                await hubConnection.StartAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"fail to connect; {ex}");
            }

            hubConnection.On<string>("Send", msg => Console.WriteLine($"Receive: {msg}"));
            Console.ReadKey();
        }
    }
}

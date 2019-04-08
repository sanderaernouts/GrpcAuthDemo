using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace GrpcAuthDemo
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Include port of the gRPC server as an application argument
            var port = args.Length > 0 ? args[0] : "50051";

            var useSsl = false;
            if (args.Length > 1)
            {
                bool.TryParse(args[1], out useSsl);
            }

            var token = string.Empty;

            if (args.Length > 2)
            {
                token = args[2];
            }

            var channel = new Channel("localhost:" + port, useSsl ? new SslCredentials() : ChannelCredentials.Insecure);
            var client = new Greeter.GreeterClient(channel);
            
            var metadata = new Metadata
            {
                { "Authorization", $"Bearer {token}"}
            };

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" }, metadata);
            Console.WriteLine("Greeting: " + reply.Message);

            await channel.ShutdownAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    public class GrpcClient
    {
        public async Task<string> Connect(string name)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
            string Mes = reply.Message; 
            Thread.Sleep(2000);
            return Mes;
        }
    }
}

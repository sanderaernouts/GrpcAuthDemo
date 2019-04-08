using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace GrpcAuthDemo
{
    [Authorize]
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var httpContenxt = context.GetHttpContext();
            var user = httpContenxt.User;
            return Task.FromResult(new HelloReply
            {
                Message = $"Hello {request.Name} (logged in as: {user.Identity.Name})"
            });
        }
    }
}

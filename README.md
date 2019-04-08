# gRPC AzureAD Authentication

A demo application using ASP.NET core 3.0 preview 4 to host a gRPC service. Authentication is setup with JWT tokens from Azure AD.

## Run the example
1. open `GrpcAuthDemo\GrpcAuthDemo.Server\appsettings.json` and replace `Domain`, `TenantId` and `ClientId` with the values of an app registration from your own Azure AD tenant.
2. rebuild the solution
3. run the server application

## Run the client
Run the client application from a command prompt:

```cmd
GrpcAuthDemo\GrpcAuthDemo.Client\bin\Debug\netcoreapp3.0\GrpcAuthDemo.Client.exe <server port> <use ssl (true/false)> <JWT token>
```

For example to run without SSL:
```cmd
GrpcAuthDemo\GrpcAuthDemo.Client\bin\Debug\netcoreapp3.0\GrpcAuthDemo.Client.exe 50051 false <JWT token>
```

## Credits
This example is based on [this blog post](https://damienbod.com/2019/03/06/security-experiments-with-grpc-and-asp-net-core-3-0/) by Damien Bod
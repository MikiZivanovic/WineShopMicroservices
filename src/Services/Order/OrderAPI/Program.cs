using OrderAPI;
using OrderApplication;
using OrderInfrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();


var app = builder.Build();

app.AddApplicationServices();


app.Run();

using OrderAPI;
using OrderApplication;
using OrderInfrastructure;
using OrderInfrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();


var app = builder.Build();

app.AddApplicationServices();

if (app.Environment.IsDevelopment()) {

    app.InitializeDatabaseAsync();
}

app.Run();

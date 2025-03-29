



using BuildingBlocks.Exceptions.CustomExceptionHandler;
using CartAPI.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCarter();
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(Program).Assembly);
    conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddMarten(opt => {
    opt.Connection(builder.Configuration.GetConnectionString("Database"));
}).UseLightweightSessions();

builder.Services.AddScoped<ICartRepository,CartRepository>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();

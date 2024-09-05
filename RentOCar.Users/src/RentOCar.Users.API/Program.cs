using RentOCar.Users.Application;
using RentOCar.Users.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructutre();


var app = builder.Build();



app.Run();

using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Common;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi()
                .AddCommon()
                .AddApplication()
                .AddExternal(builder.Configuration)
                .AddPersistence(builder.Configuration);

var app = builder.Build();

app.MapPost("/testService", async (IDeleteUserCommand service) =>
{
    return await service.Execute(1);
});

app.Run();


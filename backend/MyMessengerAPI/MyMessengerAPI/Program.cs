using Application.Interfaces.Authentication;
using Application.Interfaces.Repositories;
using Application.Services;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddDbContext<MyMessengerDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("Connection"));
});

services.AddScoped<IUserRepository, UsersRepository>();
services.AddScoped<UsersService>();

services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
        .WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

//app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();

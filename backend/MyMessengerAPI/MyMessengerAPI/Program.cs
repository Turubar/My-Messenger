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

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<UsersService>();

services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

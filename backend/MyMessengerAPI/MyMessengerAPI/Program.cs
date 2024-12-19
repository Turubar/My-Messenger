using Application.Interfaces.Authentication;
using Application.Interfaces.Repositories;
using Application.Services;
using Infrastructure;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMessengerAPI.Extensions;
using Persistence;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddApiAuthentication(configuration);

services.AddControllers();

services.AddDbContext<MyMessengerDbContext>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
        .WithOrigins("https://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
services.AddScoped<JwtOptions>();

services.AddScoped<IUserRepository, UsersRepository>();
services.AddScoped<IProfileRepository, ProfilesRepository>();

services.AddScoped<UsersService>();

services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("X-Xss-Protection", "1; mode=block");
    context.Response.Headers.Append("X-Frame-Options", "DENY");

    await next();
});

app.UseHttpsRedirection();

app.UseCors();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

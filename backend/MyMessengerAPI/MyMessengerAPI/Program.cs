using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddDbContext<MyMessengerDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("Connection"));
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

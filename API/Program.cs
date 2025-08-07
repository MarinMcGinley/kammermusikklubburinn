using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ConcertContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IConcertSeasonRepository, ConcertSeasonRepository>();

var app = builder.Build();

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ConcertContext>();
    await context.Database.MigrateAsync();
    await ConcertContextSeed.SeedAsync(context);
}
catch (System.Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();

using System.Text.Json.Serialization;
using API.Middleware;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<ConcertContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IConcertSeasonRepository, ConcertSeasonRepository>();
builder.Services.AddScoped<IConcertRepository, ConcertRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// builder.Services.AddCors();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
// app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200"));
app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ConcertContext>();
    await context.Database.MigrateAsync();

    var logger = services.GetRequiredService<ILogger<ConcertContextSeed>>();
    var seeder = new ConcertContextSeed(logger);

    await seeder.SeedAsync(context);
}
catch (System.Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();

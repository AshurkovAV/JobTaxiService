using JobTaxi.Entity;
using JobTaxiService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add services to the container.

builder.Services.AddControllers();
//Внедряем зависимость
builder.Services.AddSingleton<IJobRepository, JobRepository>();
builder.Services.AddSingleton<IDataService, DataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();

using JobTaxi.Entity;
using JobTaxiService.Service;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


// Add services to the container.

builder.Services.AddControllers();
//�������� �����������
builder.Services.AddSingleton<IJobRepository, JobRepository>();
builder.Services.AddSingleton<IDataService, DataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseStaticFiles();//���������� wwwroot

//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(
//                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
//});

app.MapControllers();
// ��������� ��������� ������������� ��� Razor Pages
app.MapRazorPages();

app.Run();

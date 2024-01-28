using Microsoft.EntityFrameworkCore;
using StudentCore.AppDbContext;
using StudentServices.Interfaces;
using StudentServices.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

//#region changes start
//var builder1 = new ConfigurationBuilder();
//builder1.SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//IConfiguration config1 = builder1.Build();
//string connectionString = config1["ConnectionString:Localhost"];
//#endregion changes completed

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddTransient<IStudentInterface, StudentService>();
builder.Services.AddScoped<IStudentInterface, StudentService>();
//builder.Services.AddDbContext<DataContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Localhost").ToString());
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Localhost"));
//});
//DataContext dataContext = builder.Services.BuildServiceProvider().GetService<DataContext>();
//dataContext?.Database.Migrate();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddDbContext<DataContext>(options=> options.UseSqlServer(Configurati))
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

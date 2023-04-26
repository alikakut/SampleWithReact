using Microsoft.EntityFrameworkCore;
using SampleWithReact.Api;
using SampleWithReact.Application;
using SampleWithReact.Infrastructure;
using SampleWithReact.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddAplication()
        .AddInfrastructure(builder.Configuration);
}
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SampleWithReactDbContext>(options =>
options.UseNpgsql
(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

var app = builder.Build();


//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();


using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tasr.Library.Services;
using Tasr.Web.Data;
using Tasr.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBootstrapBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<INavigationService, NavigationService>();
builder.Services.AddScoped<IParcelBoxService, ParcelBoxService>();
builder.Services.AddScoped<IRecordingService, RecordingService>();
builder.Services.AddScoped<IDeliverService, DeliverService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

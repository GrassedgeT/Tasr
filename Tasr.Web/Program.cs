using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tasr.Web.Data;
using Tasr.Library;
using Tasr.Library.Services.Impl;
using Tasr.Library.Services;
using Tasr.Web.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBootstrapBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IAudioService, AudioService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IAudioToTextService, AudioToTextService>();
builder.Services.AddScoped<INavigationService, NavigationService>();
builder.Services.AddScoped<IParcelBoxService, ParcelBoxService>();
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

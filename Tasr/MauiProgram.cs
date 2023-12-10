using Microsoft.Extensions.Logging;
using Tasr.Data;
using Tasr.Library.Services;
using Tasr.Library.Services.Impl;
using Tasr.Services.Impl;

namespace Tasr;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
        builder.Services.AddBootstrapBlazor();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddScoped<IAudioService, AudioService>();
		builder.Services.AddScoped<IAlertService, AlertService>();
		builder.Services.AddScoped<IAudioToTextService, AudioToTextService>();
		builder.Services.AddScoped<INavigationService, NavigationService>();
		builder.Services.AddScoped<IParcelBoxService, ParcelBoxService>();
		return builder.Build();
	}
}

using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Media;
using Microsoft.Extensions.Logging;
using Tasr.Data;
using Tasr.Library.Services;
using Tasr.Services;

namespace Tasr;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddBootstrapBlazor();
		builder.Services.AddBootstrapBlazorBaiduSpeech();
		

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddScoped<INavigationService, NavigationService>();
		builder.Services.AddScoped<IParcelBoxService, ParcelBoxService>();
		builder.Services.AddScoped<IRecordingService, RecordingService>();
		builder.Services.AddScoped<IDeliverService, DeliverService>();
		builder.Services.AddSingleton<ISpeechToText>(SpeechToText.Default);
		return builder.Build();
	}
}

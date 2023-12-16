namespace Tasr.Library.Services;

public interface INavigationService
{
	void NavigateTo(string uri);

	void NavigateTo(string uri, object parameter);
}
public static class NavigationServiceConstants
{
	public const string RecognizerPage = "/recognizer";
	public const string HomePage = "/home";
	public const string AudioPage = "/audio";
	public const string SummaryPage = "/summary";
	public const string ExportPage = "/export";
}
namespace Tasr.Library.Services;

public interface ISummarizeService
{
	Task<string> SummarizeAsync(string meetingContent);
}
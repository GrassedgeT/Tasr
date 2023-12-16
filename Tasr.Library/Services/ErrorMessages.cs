namespace Tasr.Library.Services;

public static class ErrorMessages
{
	public const string HttpClientErrorTitle = "连接错误";
	public const string RecordingErrorTitle = "语音输入错误";
	public const string HttpClientErrorButton = "确定";
	public static string GetHttpClientError(string server, string message) =>
		$"与{server}连接时发生了错误：\n{message}";
	public const string RecordingErrorButton = "确定";
	public const string TextErrorTitle = "内容不能为空";
	public const string TextErrorButton = "确定";
}
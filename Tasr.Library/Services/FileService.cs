using System.Text;

namespace Tasr.Library.Services;

public class FileService : IFileService
{
	private readonly IAlertService _alertService;
	private const string Server1 = "SpeechToText服务器";
	private const string Server2 = "punctuate服务器";
	public FileService(IAlertService alertService)
	{
		_alertService= alertService;
	}
	public async Task<string> AudioFileToText(byte[] audioFile)
	{
		using var httpClient1= new HttpClient();
		using var formData1 = new MultipartFormDataContent();
		formData1.Add(new ByteArrayContent(audioFile), "recFile", "recFile");
		HttpResponseMessage response1;
		try
		{
			response1 = await httpClient1.PostAsync(
				"http://localhost:8000/audio2text", formData1
			);
			response1.EnsureSuccessStatusCode();
		}
		catch (Exception ex)
		{
			_alertService.AlertAsync(ErrorMessages.HttpClientErrorTitle,
				ErrorMessages.GetHttpClientError(Server1, ex.Message), ErrorMessages.HttpClientErrorButton);
			return null;
		}

		var record = await response1.Content.ReadAsStringAsync();
		string result;
		var httpClient2= new HttpClient();
		HttpResponseMessage response2;
		using  var formData2 = new MultipartFormDataContent();
		try
		{
			response2 = await httpClient2.PostAsync("http://tasr.server.punctuate:8001", new StringContent(record));
			response2.EnsureSuccessStatusCode();
		}
		catch (Exception e)
		{
			await _alertService.AlertAsync(ErrorMessages.HttpClientErrorTitle,
				ErrorMessages.GetHttpClientError(Server2, e.Message),
				ErrorMessages.HttpClientErrorButton);
			return null;
		}

		return response2.ToString();
	}
}
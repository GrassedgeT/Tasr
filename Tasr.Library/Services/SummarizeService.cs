using System.Text;
using System.Text.Json;
using TheSalLab.GeneralReturnValues;

namespace Tasr.Library.Services;

public class SummarizeService :ISummarizeService
{
	private readonly IAlertService _alertService;
	private const string Server = "Tasr服务器";

	public SummarizeService(IAlertService alertService)
	{
		_alertService=alertService;
	}
	public async Task<string> SummarizeAsync(string meetingContent)
	{
		using var httpClient=new HttpClient();
		//using var formData = new MultipartFormDataContent();
		//formData.Add(new StringContent(meetingContent), "MeetingContent", "MeetingContent");
		var formData = new MultipartFormDataContent();
		formData.Add(new StringContent(meetingContent),"MeetingContent");
		HttpResponseMessage response;
		try
		{
			response =
				await httpClient.PostAsync(
					"http://localhost:5212/Home/summary", formData
				);
			response.EnsureSuccessStatusCode();
		}
		catch (Exception e)
		{
			await _alertService.AlertAsync(ErrorMessages.HttpClientErrorTitle,
				ErrorMessages.GetHttpClientError(Server, e.Message),
				ErrorMessages.HttpClientErrorButton);
			return null;
		}
		var json=await response.Content.ReadAsStringAsync();
		//反序列化
		var result = JsonSerializer.Deserialize<ServiceResultViewModel<string>>(
			json,
			new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
				IncludeFields = true
			});
		if (result.Status != ServiceResultStatus.Succeeded)
		{
			await _alertService.AlertAsync(ErrorMessages.HttpClientErrorTitle,
				ErrorMessages.GetHttpClientError(Server, string.Join("", result.Messages)),
				ErrorMessages.HttpClientErrorButton);
			return null;
		}

		return result.Result;
	}
}
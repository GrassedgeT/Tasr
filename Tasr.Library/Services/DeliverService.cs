using BootstrapBlazor.Components;
using System.Net.Http;
using System.Reflection.Metadata;

namespace Tasr.Library.Services;

public class DeliverService :IDeliverService
{
	public async Task<HttpResponseMessage> UploadAudio(Blob audioBlob)
	{
		var array = audioBlob.GetBytes().Array;
		var stream = new MemoryStream(array);
		var content = new StreamContent(stream);
		content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/webm");
		content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
		{
			Name = "file",
			FileName = "audio.webm"
		};
		// 使用HttpClient发送Post请求到后端
		var httpClient= new HttpClient();
		HttpResponseMessage response = await httpClient.PostAsync("/api/voice", content);
		return response;
		
	}
	
}
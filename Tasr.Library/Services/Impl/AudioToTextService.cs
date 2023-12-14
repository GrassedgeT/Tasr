using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tasr.Library.Utils;
using TheSalLab.GeneralReturnValues;

namespace Tasr.Library.Services.Impl
{
    public class AudioToTextService : IAudioToTextService
    {
        private readonly IAlertService _alertService;

        private readonly string server = "Tasr服务器";
        public AudioToTextService(IAlertService alertService)
        {
            _alertService = alertService;
        }

        public async Task<string> FileToTextAsync(byte[] audio)
        {
            using var httpClient = new HttpClient();

            using var formData = new MultipartFormDataContent();
            formData.Add(new ByteArrayContent(audio), "File", "audio.wav");
            HttpResponseMessage response;
            try
            {
                response = await httpClient.PostAsync("http://localhost:5182/home/FileToText", formData);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                await _alertService.AlertAsync(
                        ErrorMessages.HttpClientErrorTitle,
                        ErrorMessages.GetHttpClientError(server, e.Message),
                        ErrorMessages.ErrorButton                    );
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ServiceResultViewModel<string>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true, IncludeFields = true
                });
            if (result.Status != ServiceResultStatus.Succeeded)
            {
                await _alertService.AlertAsync(
                   ErrorMessages.HttpClientErrorTitle,
                   string.Join(" ", result.Messages),
                   ErrorMessages.ErrorButton
                );
                return null;
            }

            return result.Result;
        }
    }
}

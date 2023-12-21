using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tasr.Library.Utils;
using Tasr.Models;
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

        public async Task<FileToTextResult> FileToTextAsync(byte[] audio)
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

            try
            {
                var resp_result = await response.Content.ReadFromJsonAsync<ServiceResultViewModel<String>>();
                
                var result = JsonConvert.DeserializeObject<FileToTextResult>(resp_result.Result);
                
                if (resp_result.Status != ServiceResultStatus.Succeeded)
                {
                    await _alertService.AlertAsync(
                       ErrorMessages.HttpClientErrorTitle,
                       string.Join(" ", resp_result.Messages),
                       ErrorMessages.ErrorButton
                    );
                    return null;
                }
             
                return result;
            }
            catch (Exception e)
            {
                await _alertService.AlertAsync(
                                       ErrorMessages.HttpClientErrorTitle,
                                       ErrorMessages.GetHttpClientError(server, e.Message),
                                       ErrorMessages.ErrorButton);
                return null;
            }
           
            
        }
    }
}

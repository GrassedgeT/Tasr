using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tasr.Library.Utils;
using Tasr.Models;
using TheSalLab.GeneralReturnValues;

namespace Tasr.Library.Services.Impl
{
    public class SummarizeService : ISummarizeService
    {
        private readonly IAlertService _alertService;

        private const string Server = "Tasr服务器";

        public SummarizeService(IAlertService alertService){
            _alertService = alertService;
        }
        public async Task<string> GetSummaryAsync(List<Sentence> segments)
        {
            using var httpClient = new HttpClient();

            using var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(JsonSerializer.Serialize<List<Sentence>>(segments)), "Content");

            HttpResponseMessage response;
            try
            {
                response =
                    await httpClient.PostAsync("http://localhost:5182/home/summary", formData);
                response.EnsureSuccessStatusCode();
            } catch (Exception e)
            {
                await _alertService.AlertAsync(ErrorMessages.HttpClientErrorTitle,
                ErrorMessages.GetHttpClientError(Server, e.Message),
                ErrorMessages.ErrorButton);
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
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
                    ErrorMessages.GetHttpClientError(Server,
                        string.Join(" ", result.Messages)),
                    ErrorMessages.ErrorButton);
                return null;
            }

            return result.Result;
        }
    }
}

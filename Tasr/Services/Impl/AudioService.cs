using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasr.Library.Services;
using Tasr.Library.Utils;
using Tasr.Models;


namespace Tasr.Services.Impl
{
    public class AudioService : IAudioService
    {
        private readonly IAlertService _alertService;

        private readonly PickOptions wavOptions = new()
        {
            PickerTitle = "请选择wav格式的音频文件",
            FileTypes = PickFileTypes.wavFileType
        };  

        public AudioService(IAlertService alertService)
        {
            _alertService = alertService;
        }
        public async Task<byte[]> PickAudioAsync()
        {
            var audio = await FilePicker.Default.PickAsync(wavOptions);

            if (audio is null)
            {
                await _alertService.AlertAsync(
                    ErrorMessages.AudioErrorTitle, 
                    "音频选择失败", 
                    ErrorMessages.ErrorButton
                );
                return null;
            }

            await using var audioStream = await audio.OpenReadAsync();
            using var ms = new MemoryStream();
            await audioStream.CopyToAsync(ms);
            return ms.ToArray(); 
        }

        public async Task<byte[]> RecordAudioAsync()
        {
            await _alertService.AlertAsync(
                ErrorMessages.AudioErrorTitle, 
                "音频选择失败", 
                ErrorMessages.ErrorButton
            );
            return null;

        }
    }
}

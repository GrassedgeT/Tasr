using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Library.Pages
{
    public partial class NewRec
    {
        private async Task PickAsync()
        {
            var bytes = await _audioService.PickAudioAsync();

            if (bytes is null)
            {
                return;
            }
            await _AudioToTextService.AudioToTextAsync(bytes);
        }

        private async Task RecordAsync()
        {
            await _audioService.RecordAudioAsync();
        }
    }
}

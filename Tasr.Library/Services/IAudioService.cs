using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Library.Services
{
    public interface IAudioService
    {
        //挑选音频
        Task<byte[]> PickAudioAsync();
        
        //录制音频
        Task<byte[]> RecordAudioAsync();
    }
}

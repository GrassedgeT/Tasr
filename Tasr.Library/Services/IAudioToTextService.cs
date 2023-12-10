using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Library.Services
{
    public interface IAudioToTextService
    {
        Task<string> FileToTextAsync(byte[] audio);

        //TODO 流式语音识别接口
    }
}

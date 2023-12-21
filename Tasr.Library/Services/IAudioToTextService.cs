using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasr.Models;

namespace Tasr.Library.Services
{
    public interface IAudioToTextService
    {
        Task<FileToTextResult> FileToTextAsync(byte[] audio);

        //TODO 流式语音识别接口
    }
}

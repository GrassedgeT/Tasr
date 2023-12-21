using Tasr.Library.Services;

namespace Tasr.Web.Services.Impl
{
    public class AudioService : IAudioService
    {
        public Task<byte[]> PickAudioAsync()
        {
             throw new NotImplementedException();           
        }

        public Task<byte[]> RecordAudioAsync()
        {
            throw new NotImplementedException();
        }
    }
}

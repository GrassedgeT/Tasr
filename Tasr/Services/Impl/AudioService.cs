using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasr.Library.Services;

namespace Tasr.Services.Impl
{
    public class AudioService : IAudioService
    {
        private readonly IAlertService _alertService;

        public AudioService(IAlertService alertService)
        {
            _alertService = alertService;
        }
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

using System.Reflection.Metadata;

namespace Tasr.Library.Services;

public interface IDeliverService
{
	Task<HttpResponseMessage> UploadAudio(Blob audioBlob);
}
namespace Tasr.Library.Services;

public interface IRecordingService
{
	//Task InitAsync();
	Task StartRecordingAsync(CancellationToken cancellationToken);
	Task PauseRecordingAsync();
	Task ResumeRecordingAsync();
	Task StopRecordingAsync();

}
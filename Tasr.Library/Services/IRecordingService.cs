namespace Tasr.Library.Services;

public interface IRecordingService
{
	//Task InitAsync();
	//Task StartRecordingAsync(CancellationToken cancellationToken);
	Task StartRecordingAsync();
	Task PauseRecordingAsync();
	Task ResumeRecordingAsync();
	Task StopRecordingAsync();

}
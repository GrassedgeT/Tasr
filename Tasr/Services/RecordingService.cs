using System.Globalization;
using CommunityToolkit.Maui.Media;
using Tasr.Library.Services;

namespace Tasr.Services;

public class RecordingService :IRecordingService
{
	private readonly IAlertService _alertService;
	private readonly ISpeechToText _speechToText;

	public RecordingService(IAlertService alertService, ISpeechToText speechToText)
	{
		_alertService = alertService;
		_speechToText = speechToText;
	}
	//public Task InitAsync()
	//{
	//	throw new NotImplementedException();
	//}

	public async Task StartRecordingAsync(CancellationToken cancellationToken)
	{
		var isGranted = await _speechToText.RequestPermissions(cancellationToken);
		if (!isGranted)
		{
			await _alertService.AlertAsync(ErrorMessages.RecordingErrorTitle,
				"设备不支持语音输入。", ErrorMessages.RecordingErrorButton);
			return;
		}

		//_speechToText.RecognitionResultUpdated += OnRecognitionTextUpdated;
		_speechToText.StartListenAsync(CultureInfo.CurrentCulture, CancellationToken.None);
	}
	

	public Task PauseRecordingAsync()
	{
		throw new NotImplementedException();
	}

	public Task ResumeRecordingAsync()
	{
		throw new NotImplementedException();
	}

	public Task StopRecordingAsync()
	{
		throw new NotImplementedException();
	}
}
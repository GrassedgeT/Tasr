using System.Reflection.Metadata;
using BootstrapBlazor.Components;
using Tasr.Library.Services;

namespace Tasr.Library.Pages

{
	public partial class Recognizer
	{
		private bool isRecording = false; // 记录是否正在录音
		private bool isPaused = false; // 记录是否暂停录音
		private Blob _audioBlob;

		//protected override async Task OnInitializedAsync()
		//{
		//	await _recordingService.InitAsync();
		//}


		private async Task StartRecording()
		{
			// 开始录音
			await _recordingService.StartRecordingAsync();
			isRecording = true;
		}

	private async Task PauseRecording()
		{
			// 暂停录音
			await _recordingService.PauseRecordingAsync();
			isRecording = false;
			isPaused = true;
		}

	private async Task ResumeRecording()
		{
			// 继续录音
			await _recordingService.ResumeRecordingAsync();
			isRecording = true;
			isPaused = false;
		}

		private async Task StopRecording()
		{
			// 停止录音
			await _recordingService.StopRecordingAsync();
			isRecording = false;
			isPaused = false;
		}

		private async Task UploadAudio()
		{
			HttpResponseMessage response = await _deliverService.UploadAudio(_audioBlob);
			if (response.IsSuccessStatusCode)
			{
				// 显示上传成功的消息
				await _toastService.Show(new ToastOption
				{
					Category = ToastCategory.Success,
					Title = "上传成功",
					Content = "语音文件已成功上传到后端"
				});
			}
			else
			{
				// 显示上传失败的消息
				await _toastService.Show(new ToastOption
				{
					Category = ToastCategory.Error,
					Title = "上传失败",
					Content = "语音文件上传到后端时发生错误"
				});
			}
		}
		

	}
}

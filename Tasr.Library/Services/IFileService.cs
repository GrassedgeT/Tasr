namespace Tasr.Library.Services;

public interface IFileService
{
	//上传文件将音频文件转化为文本
	Task<string> AudioFileToText(byte[] audioFile);
}
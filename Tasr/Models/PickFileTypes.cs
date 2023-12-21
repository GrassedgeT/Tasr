namespace Tasr.Models;

public class PickFileTypes
{
    public static readonly FilePickerFileType wavFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
    {
        { DevicePlatform.Android, new[] { "audio/wav" } },
        { DevicePlatform.iOS, new[] { "com.microsoft.waveform-audio" } },
        { DevicePlatform.WinUI, new [] { ".wav" } },
        { DevicePlatform.macOS, new [] { "wav" }},
    });
}
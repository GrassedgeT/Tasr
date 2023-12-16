using Tasr.Library.Models;

namespace Tasr.Library.Services;

public interface IExportAsWord
{
	Task<string> exportAsWord(Meeting meeting);
}
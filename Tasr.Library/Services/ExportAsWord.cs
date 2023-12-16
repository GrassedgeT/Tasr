using Tasr.Library.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Tasr.Library.Services;

public class ExportAsWord :IExportAsWord
{
	public async Task<string> exportAsWord(Meeting meeting)
	{
		string documentName = meeting.title + "_" + meeting.host + "_meetingDocument.docx";
		string DocumentPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
			documentName);
		DocX document=DocX.Create(DocumentPath);
		document.InsertParagraph(meeting.title).FontSize(18)
			.Bold().Alignment = Alignment.center;
		document.InsertParagraph("主持人:" + meeting.host)
			.FontSize(12)
			.Alignment = Alignment.center;
		document.InsertParagraph("日期:"+meeting.time)
			.FontSize(12)
			.Alignment = Alignment.right;
		document.InsertParagraph("会议内容:")
			.FontSize(14)
			.Bold()
			.Alignment = Alignment.left;
		document.InsertParagraph(meeting.content)
			.FontSize(14)
			.Alignment= Alignment.left;
		document.Save();
		return DocumentPath;
	}
}
namespace Tasr.Library.Models;
[SQLite.Table("meetings")]
public class Meeting
{
	[SQLite.Column("id"),SQLite.PrimaryKey,SQLite.AutoIncrement]
	public int Id { get; set; }

	[SQLite.Column("title")]
	public string Title { set; get; }//会议主题

	[SQLite.Column("summaryResult")]
	public string SummaryResult { set; get; }//总结后的结果

	[SQLite.Column("result")]
	public string Result { set; get; }//FileToTextResult

	[SQLite.Column("mergeSentences")]
	public string MergeSentences { set; get; }//拆分后的句子


	[SQLite.Column("time")]
	public DateTime Time { set; get; }//保存时间
}

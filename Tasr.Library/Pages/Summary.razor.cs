using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tasr.Library.Services;

namespace Tasr.Library.Pages
{
	public partial class Summary
	{
		[Parameter]
		public string Ticket { set; get; } = string.Empty;
		public string meetingContent = string.Empty;
		public string result= string.Empty;
		public bool _isUpload=false;
		public bool _isLoading = true;
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			var parameter = _parcelBoxService.Get(Ticket) as string;
			if (parameter == null)
			{
				return;
			}

			meetingContent = parameter.ToString();
			StateHasChanged();
			
		}

		public async Task summarize()
		{
			_isUpload = true;
			if (string.IsNullOrWhiteSpace(meetingContent))
			{
				await _alterService.AlertAsync(ErrorMessages.TextErrorTitle, "会议内容不能为空", ErrorMessages.TextErrorButton);
			}

			int maxLength = 1500;
			List<string>segments=SplitText(meetingContent,maxLength);
			StringBuilder outcome = new StringBuilder();
			foreach (var segment in segments)
			{
				string summarizeAsync = await _summarizeService.SummarizeAsync(segment);
				outcome.Append(summarizeAsync);
			}
			result = await _summarizeService.SummarizeAsync(outcome.ToString());	
			_isLoading=false;
		}

		public List<string> SplitText(string meetingContent, int maxLength)
		{
			List<string>segments=new List<string>();
			StringBuilder currentSegment=new StringBuilder();
			foreach (string sentence in SplitIntoSentences(meetingContent))
			{
				if (currentSegment.Length + sentence.Length + 1 <= maxLength)
				{
					currentSegment.Append(sentence + "");
				}
				else 				{
					segments.Add(currentSegment.ToString().Trim());
					currentSegment.Clear();
					currentSegment.Append(sentence + "");
				}
			}
			return segments;
		}

		public IEnumerable<string> SplitIntoSentences(string text)
		{
			//return text.Split('。', '！', '？');
			return Regex.Split(text,@"[。！？]");
		}
	}
}

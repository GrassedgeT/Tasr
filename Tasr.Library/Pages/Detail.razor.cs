using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tasr.Library.Models;
using Tasr.Library.Services;
using Tasr.Models;

namespace Tasr.Library.Pages
{
	public partial class Detail
	{
		[Parameter]
		public string Ticket { get; set; } = string.Empty;
		private string? _summaryResult;
		private FileToTextResult? _result;
		private List<Sentence> _mergedSentences=new ();
		private Dictionary<int,bool>_sentenceState=new ();
		private DateTime? _time;
		private Meeting meeting;
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (!firstRender)
			{
				return;
			}

			if (string.IsNullOrEmpty(Ticket))
			{
				return;
			}

			var parammeter = _parcelBoxService.Get(Ticket) as Meeting;
			if (parammeter == null)
			{
				return;
			}
			meeting = (Meeting)parammeter;
			_mergedSentences = JsonConvert.DeserializeObject<List<Sentence>>(meeting.MergeSentences);
			JObject json = JObject.Parse(meeting.Result);
			_result=new FileToTextResult
			{
				Text = (string)json["Text"],
				Sentences = json["Sentences"].ToObject<List<Sentence>>()
			};
			//_result = JsonConvert.DeserializeObject<FileToTextResult>(meeting.SummaryResult);
			_time = meeting.Time;
			_summaryResult = meeting.SummaryResult;
			StateHasChanged();
		}
		public string GetFormattedTime(int time)
		{
			TimeSpan timeSpan = TimeSpan.FromMilliseconds(time);

			string formattedTime = timeSpan.ToString(@"hh\:mm\:ss");

			return formattedTime;
		}

		private async Task Back()
		{
			_navigationService.NavigateTo(NavigationServiceConstants.History);
		}
	}
}

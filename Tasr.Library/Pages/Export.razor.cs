using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tasr.Library.Models;

namespace Tasr.Library.Pages
{
	public partial class Export
	{
		[Parameter]
		public string Ticket { set; get; } = string.Empty;
		public string Title=string.Empty;
		public string Host = string.Empty;
		public string Time = string.Empty;
		public string Content=string.Empty;
		public string WordPath=string.Empty;
		private bool _isUpload = false;
		private bool _isLoading = true;
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			//if (string.IsNullOrWhiteSpace(Ticket))
			//{
			//	return;
			//}

			var parameter = _parcelBoxService.Get(Ticket) as string;
			if (parameter == null)
			{
				return;
			}

			Content = parameter.ToString();
			StateHasChanged();
		}
		
		private async Task ExportAsWord()
		{
			_isUpload=true;
			Meeting meeting=new Meeting();
			meeting.title=Title;
			meeting.host=Host;
			meeting.time=Time;
			meeting.content=Content;
			WordPath = await _exportAsWord.exportAsWord(meeting);
			_isLoading = false;
		}
	}
}

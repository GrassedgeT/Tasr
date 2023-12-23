using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Newtonsoft.Json;
using Tasr.Library.Models;
using Tasr.Library.Services;
using Console = BootstrapBlazor.Components.Console;

namespace Tasr.Library.Pages
{
    
    public partial class History
    {
	    private List<Meeting> meetings=new();

	    protected override async Task OnAfterRenderAsync(bool firstRender)
	    {
		    meetings=await _meetingStorage.GetMeetingsAsync();
			StateHasChanged();
	    }

	    private async Task CheckMeeting(int id)
	    {
		    Meeting meetingChecked = await _meetingStorage.GetMeetingAsync(id);
			_navigationService.NavigateTo(NavigationServiceConstants.Detail,meetingChecked);
	    }

	    private async Task DeleteMeeting(int id)
	    {
		    try
		    {
			    await _meetingStorage.DeleteMeetingAsync(id);
		    }
		    catch (Exception e)
		    {
			    System.Console.WriteLine(e);
			    throw;
		    }
			StateHasChanged();
	    }

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasr.Library.Services;

namespace Tasr.Library.Pages
{
	public partial class Home
	{
		public void recognizer()
		{
			_navigationService.NavigateTo(NavigationServiceConstants.RecognizerPage);
		}
		public void audio()
		{
			_navigationService.NavigateTo(NavigationServiceConstants.AudioPage);
		}
		public void summary()
		{
			_navigationService.NavigateTo(NavigationServiceConstants.SummaryPage);
		}
	}
}

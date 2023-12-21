using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Library.Services
{
    public interface INavigationService
    {
        void NavigateTo(string uri);
        void NavigateTo(string uri, object parameter);
    }

    public static class NavigationServiceConstants
    {
        public const string NewRec = "/newrec";
        public const string History = "/history";
        public const string FileToTextPage = "/FileToTextPage";
    }
}

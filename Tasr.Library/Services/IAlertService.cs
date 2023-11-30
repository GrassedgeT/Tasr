using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Library.Services
{
    public interface IAlertService
    {
        Task AlertAsync(string title, string message, string button);
    }
}

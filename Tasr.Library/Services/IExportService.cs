using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasr.Library.Models;

namespace Tasr.Library.Services
{
    public interface IExportService
    {
        Task<string> ExportAsWord(ExportResult exportResult);
    }
}

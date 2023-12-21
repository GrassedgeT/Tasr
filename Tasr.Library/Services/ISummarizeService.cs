using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasr.Models;

namespace Tasr.Library.Services
{
    public interface ISummarizeService
    {
        Task<string> GetSummaryAsync(List<Sentence> sentences);
    }
}

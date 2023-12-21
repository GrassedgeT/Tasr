using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Models
{
    public class AudioToTextResult
    {
        public string text { get; set; }
        public List<Sentence> sentences { get; set; }
        public class Sentence
        {
            string text { get; set; }
            int start { get; set; }
            int end { get; set; }
        }
    }
}

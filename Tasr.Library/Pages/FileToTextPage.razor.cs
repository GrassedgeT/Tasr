using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasr.Models;

namespace Tasr.Library.Pages
{
    public partial class FileToTextPage
    {
        [Parameter]
        public string Ticket { get; set; } = string.Empty;

        private FileToTextResult? _result;

        private string? summaryResult;

        private bool isSummary = false;

        private string summaryBtnText { get; set; } = "生成总结";

        private List<Sentence> _mergedSentences;

        private Dictionary<int, bool> _sentenceState = new Dictionary<int, bool>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (! firstRender)
            {
                return;
            }

            if (string.IsNullOrEmpty(Ticket))
            {
                return;
            }

            var parammeter = _parcelBoxService.Get(Ticket) as Task<FileToTextResult>;

            if (parammeter is null)
            {
                return;
            }

            _result = await parammeter;

            _mergedSentences = MergeSentences(_result.Sentences);

            StateHasChanged();
        } 
        
        public string GetFormattedTime(int time)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(time);

            string formattedTime = timeSpan.ToString(@"hh\:mm\:ss");

            return formattedTime;   
        }

        public List<Sentence> MergeSentences(List<Sentence> sentences)
        {
            List<Sentence> mergedSentences = new List<Sentence>();

            Sentence segment = new Sentence();
            segment.Text = "  ";
            int count = 0;
            foreach (var sentence in sentences)
            {
                if(segment.Start == 0)
                {
                    segment.Start = sentence.Start;
                }
                segment.Text += sentence.Text;
                if (sentence.Text.EndsWith("。") || sentence.Text.EndsWith("！") || sentence.Text.EndsWith("？"))
                {
                    count++;
                }           
                if (count == 4)
                {
                    segment.End = sentence.End;
                    _sentenceState.Add(segment.Start, false);
                    mergedSentences.Add(segment);
                    segment = new Sentence();
                    segment.Text = string.Empty;
                    count = 0;
                }
            }
            
            return mergedSentences;
        }   

        public void ToSummary()
        {
            isSummary = true;
            summaryBtnText = "重新生成";
            StateHasChanged();
        }
        
        public void Save()
        {

        }

        public void Export()
        {

        }

        public void Edit(int id)
        {
            _sentenceState[id] = true;
            StateHasChanged();
        }

        public void FinEdit(int id)
        {
            _sentenceState[id] = false;
            StateHasChanged();
        }

        public void DelSentence(int id)
        {
            _mergedSentences.Remove(_mergedSentences.Find(x => x.Start == id));
            StateHasChanged();
        }
    }
}

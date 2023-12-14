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

        private string? SummaryResult;

        private bool isSummary = false;

        private string summaryBtnText { get; set; } = "生成总结";

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

            StateHasChanged();
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

    }
}

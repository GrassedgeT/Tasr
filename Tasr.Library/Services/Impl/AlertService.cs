using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootstrapBlazor.Components;

namespace Tasr.Library.Services.Impl
{
    public class AlertService : IAlertService
    {
        private readonly SwalService _swalService;

        public AlertService(SwalService swalService)
        {
            _swalService = swalService;
        }

        public async Task AlertAsync(string title, string message, string button) =>
            await _swalService.Show(new SwalOption
            {
                Category = SwalCategory.Error,
                Title = title,
                Content = message,
                CloseButtonText = button
            });

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Tasr.Library.Services.Impl
{
    public class NavigationService : INavigationService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IParcelBoxService _parcelBoxService;

        public NavigationService(NavigationManager navigationManager, IParcelBoxService parcelBoxService){
            _navigationManager = navigationManager;
            _parcelBoxService = parcelBoxService;
        }
        public void NavigateTo(string uri) =>
            _navigationManager.NavigateTo(uri);
       

        public void NavigateTo(string uri, object parameter)
        {
            var token = _parcelBoxService.Put(parameter);
            _navigationManager.NavigateTo($"{uri}/{token}");
        }
    }   
}

using Prism.Commands;
using Prism.Mvvm;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomStripes.ViewModels
{
	public class StripesPageViewModel : BindableBase
	{
        private IAppDataService _appDataService;

        private string _coloursString;
        public string ColoursString
        {
            get { return _coloursString; }
            set { SetProperty(ref _coloursString, value); }
        }
  
        public StripesPageViewModel(IAppDataService appDataService)
        {
            _appDataService = appDataService;
            ColoursString = string.Join(", ", _appDataService.SelectedColours.Select(c =>c.Name));
        }
	}
}

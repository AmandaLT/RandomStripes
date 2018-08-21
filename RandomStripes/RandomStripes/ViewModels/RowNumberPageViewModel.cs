using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomStripes.ViewModels
{
	public class RowNumberPageViewModel : ViewModelBase
	{
        private readonly IPageDialogService _dialogService;

        public ICommand NextCommand { get; set; }

        public RowNumberPageViewModel(INavigationService navigationService, IAppDataService appDataService, IPageDialogService dialogService)
            : base(navigationService, appDataService)
        {
            Title = "Row Number";
            _dialogService = dialogService;

            NextCommand = new Command<string>(NextPage);
        }

        public void NextPage(string rows)
        {
            if(string.IsNullOrEmpty(rows))
            {
                _dialogService.DisplayAlertAsync("", "Oops, please enter a number of rows", "Ok");
                return;
            }
            var rowsCount = int.Parse(rows);
            _appDataService.RowCount = rowsCount;
            NavigationService.NavigateAsync("RowHeightsPage");
        }
    }
}

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
	public class RowHeightsPageViewModel : ViewModelBase
    {
       
        public ICommand NextCommand { get; set; }
        public ICommand ToggledCommand { get; set; }
        public List<int> rowHeights { get; set; }

        private IPageDialogService _dialogService;

        public RowHeightsPageViewModel(INavigationService navigationService, IAppDataService appDataService, IPageDialogService dialogService)
         : base(navigationService, appDataService)
        {
            Title = "Row Heights";

            _dialogService = dialogService;
            rowHeights = new List<int>();

            NextCommand = new Command(NextPage);
            ToggledCommand = new Command<string>(HeightToggled);
        }

        private void HeightToggled(string heightString)
        {
            var height = int.Parse(heightString);
            if(rowHeights.Contains(height))
            {
                rowHeights.Remove(height);
            }
            else
            {
                rowHeights.Add(height);
            }
        }

        public void NextPage()
        {
            if(!rowHeights.Any())
            {
                _dialogService.DisplayAlertAsync("", "Oops, please select at least one row height", "Ok");
                return;
            }
           _appDataService.RowHeights = rowHeights;
           NavigationService.NavigateAsync("ColourSelectPage");
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomStripes.ViewModels
{
	public class ColourSelectPageViewModel : ViewModelBase
	{
        private int rowCount;
        public int RowCount
        {
           get{ return rowCount; }
           set { SetProperty(ref rowCount, value); }
        }

        private string rowHeights;
        public string RowHeights
        {
            get { return rowHeights; }
            set { SetProperty(ref rowHeights, value); }
        }

        public ICommand NextCommand { get; set; }

        public ColourSelectPageViewModel(INavigationService navigationService, IAppDataService appDataService)
         : base(navigationService, appDataService)
        {
            Title = "Colour Selection";

            RowCount = _appDataService.RowCount;
            RowHeights = string.Join(",", _appDataService.RowHeights);

            NextCommand = new Command<string>(NextPage);
        }

        private void NextPage(string colourSelectType)
        {
            if (colourSelectType.ToLower() == "custom")
            {
                NavigationService.NavigateAsync("CustomColourSelectPage");
            }
            else
            {
                NavigationService.NavigateAsync("PaletteColourSelectPage");
            }
        }
    }
}

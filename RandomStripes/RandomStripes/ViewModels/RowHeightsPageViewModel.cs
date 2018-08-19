using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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

        public RowHeightsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Row Heights";

            NextCommand = new Command(NextPage);
        }

        private void NextPage()
        {
            //var rowsCount = int.Parse(rows);
            //AppData.RowCount = rowsCount;
            NavigationService.NavigateAsync("ColourSelectPage");
        }
    }
}

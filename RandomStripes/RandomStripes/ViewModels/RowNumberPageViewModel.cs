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
	public class RowNumberPageViewModel : ViewModelBase
	{
        public ICommand NextCommand { get; set; }

        public RowNumberPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Row Number";

            NextCommand = new Command<string>(NextPage);
        }

        private void NextPage(string rows)
        {
            var rowsCount = int.Parse(rows);
            AppData.RowCount = rowsCount;
            NavigationService.NavigateAsync("RowHeightsPage");
        }
    }
}

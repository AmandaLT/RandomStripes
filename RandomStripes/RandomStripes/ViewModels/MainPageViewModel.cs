using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomStripes.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand NextCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IAppDataService appDataService)
         : base(navigationService, appDataService)
        {
            Title = "Random Stripes Generator";

            NextCommand = new Command(NextPage);
        }

        private void NextPage()
        {
            NavigationService.NavigateAsync("RowNumberPage");
        }
    }
}

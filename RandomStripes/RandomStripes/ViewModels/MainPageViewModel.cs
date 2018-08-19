using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            NextCommand = new Command(NextPage);
        }

        private void NextPage()
        {
            // save the row number
            NavigationService.NavigateAsync("RowNumberPage");
        }
    }
}

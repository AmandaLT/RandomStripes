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
        public ICommand ToggledCommand { get; set; }
        private List<int> rowHeights { get; set; }

        public RowHeightsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Row Heights";

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

        private void NextPage()
        {
            AppData.RowHeights = rowHeights;
           NavigationService.NavigateAsync("ColourSelectPage");
        }
    }
}

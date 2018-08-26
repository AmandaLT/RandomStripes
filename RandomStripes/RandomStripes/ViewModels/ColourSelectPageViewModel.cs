using Prism.Navigation;
using RandomStripes.Services;
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
               

        public ICommand NextCommand { get; set; }

        public ColourSelectPageViewModel(INavigationService navigationService, IAppDataService appDataService)
         : base(navigationService, appDataService)
        {
            Title = "Colour Selection";

            RowCount = _appDataService.RowCount;

            NextCommand = new Command<string>(NextPage);
        }

        public void NextPage(string colourSelectType)
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

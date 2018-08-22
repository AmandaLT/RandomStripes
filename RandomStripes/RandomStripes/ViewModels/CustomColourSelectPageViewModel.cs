using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RandomStripes.Models;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomStripes.ViewModels
{
	public class CustomColourSelectPageViewModel : ViewModelBase
	{
        private readonly IColoursService _coloursService;
        public List<ColourItem> Colours { get; set; }
        
        public ICommand ColourSelectCommand { get; set; }
        public ICommand NextCommand { get; set; }

        public CustomColourSelectPageViewModel(INavigationService navigationService, IAppDataService appDataService, IColoursService coloursService)
            :base(navigationService, appDataService)
        {
            ColourSelectCommand = new Command<ColourItem>(ColourSelect);
            NextCommand = new Command(NextPage);

            _coloursService = coloursService;
            Colours = _coloursService.GetColours();
        }

        public void ColourSelect(ColourItem colour)
        {
            colour.IsSelected = !colour.IsSelected;
        }

        public void NextPage()
        {
            var selectedColours = Colours.Where(c => c.IsSelected).ToList();
            _appDataService.SelectedColours = selectedColours;

            NavigationService.NavigateAsync("StripesPage");
        }
    }
}

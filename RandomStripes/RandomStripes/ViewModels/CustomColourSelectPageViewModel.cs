using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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
        private readonly IPageDialogService _dialogService; 
        private readonly IColoursService _coloursService;
        public List<ColourItem> Colours { get; set; }
        
        public ICommand ColourSelectCommand { get; set; }
        public ICommand NextCommand { get; set; }

        public CustomColourSelectPageViewModel(INavigationService navigationService, IAppDataService appDataService, 
            IColoursService coloursService, IPageDialogService dialogService)
            :base(navigationService, appDataService)
        {
            ColourSelectCommand = new Command<ColourItem>(ColourSelect);
            NextCommand = new Command<string>(NextPage);

            _coloursService = coloursService;
            Colours = _coloursService.GetColours();

            _dialogService = dialogService;
        }

        public void ColourSelect(ColourItem colour)
        {
            colour.IsSelected = !colour.IsSelected;
        }

        public void NextPage(string stripeType)
        {
            try
            {
                var selectedColours = Colours.Where(c => c.IsSelected).ToList();

                if (!selectedColours.Any())
                {
                    _dialogService.DisplayAlertAsync("", "Oops, please select some colours", "Ok");
                    return;
                }

                _appDataService.SelectedColours = selectedColours;

                bool randomStripes = stripeType == "random";
                NavigationService.NavigateAsync($"StripesPage?random={randomStripes}");

            }
            catch(Exception ex)
            {
                var s = ex.Message;
            }
        }
    }
}

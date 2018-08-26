using Prism.Navigation;
using Prism.Services;
using RandomStripes.Services;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomStripes.ViewModels
{
    public class PaletteColourSelectPageViewModel : ViewModelBase
    {
        private IPageDialogService _dialogService;
        private IColoursService _coloursService;

        public List<ColourPalette> Palettes { get; set; }        
        private ColourPalette selectedPalette { get; set; }

        public ICommand PaletteSelectCommand { get; set; }
        public ICommand NextCommand { get; set; }

        public PaletteColourSelectPageViewModel(INavigationService navigationService, IAppDataService appDataService,
            IPageDialogService dialogService, IColoursService coloursService) 
            :base(navigationService, appDataService)
        {

            _dialogService = dialogService;
            _coloursService = coloursService;

            Palettes = _coloursService.GetColourPalettes();
             
            PaletteSelectCommand = new Command<ColourPalette>(PaletteSelect);
            NextCommand = new Command<string>(NextPage);
        }

        public void PaletteSelect(ColourPalette palette)
        {
            if (selectedPalette != null)
            {
                selectedPalette.IsSelected = false;
            }

            palette.IsSelected = true;
            selectedPalette = palette;
        }

        public void NextPage(string stripeType)
        {
            if (selectedPalette == null)
            {
                _dialogService.DisplayAlertAsync("", "Oops, please select a colour palette", "Ok");
                return;
            }

            _appDataService.SelectedColours = selectedPalette.Colours;

            bool randomStripes = stripeType == "random";
            NavigationService.NavigateAsync($"StripesPage?random={randomStripes}");
        }

    }

 
}
    
	


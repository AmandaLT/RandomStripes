using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using RandomStripes.Models;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<ColourItem> SelectedColours { get; set; }
        
        public ICommand ColourSelectCommand { get; set; }
        public ICommand NextCommand { get; set; }

        public CustomColourSelectPageViewModel(INavigationService navigationService, IAppDataService appDataService, 
            IColoursService coloursService, IPageDialogService dialogService)
            :base(navigationService, appDataService)
        {
            _dialogService = dialogService;

            ColourSelectCommand = new Command<ColourItem>(ColourSelect);
            NextCommand = new Command<string>(NextPage);

            _coloursService = coloursService;
            Colours = _coloursService.GetColours();

            SelectedColours = new ObservableCollection<ColourItem>();            
        }

        public void ColourSelect(ColourItem colour)
        {
            colour.IsSelected = !colour.IsSelected;
            if(colour.IsSelected)
            {
                SelectedColours.Add(colour);
            }
            else
            {
                SelectedColours.Remove(colour);
            }
        }

        public void NextPage(string stripeType)
        {
            try
            {
                if (!SelectedColours.Any())
                {
                    _dialogService.DisplayAlertAsync("", "Oops, please select some colours", "Ok");
                    return;
                }

                _appDataService.SelectedColours = SelectedColours.ToList();

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

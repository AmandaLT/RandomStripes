using Prism.Mvvm;
using Prism.Navigation;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomStripes.ViewModels
{
    public class StripesPageViewModel : BindableBase, INavigatingAware
	{
        private IAppDataService _appDataService;
        private IStripesGenerator _stripesGenerator;
            
        private List<ColourItem> _stripes;
        public List<ColourItem> Stripes
        {
            get { return _stripes; }
            set { SetProperty(ref _stripes, value); }
        }

        public ICommand GenerateStripesCommand { get; set; }

        private bool _randomStripes;
        public bool RandomStripes
        {
            get { return _randomStripes; }
            set { SetProperty(ref _randomStripes, value); }
        }

        public StripesPageViewModel(IAppDataService appDataService, IStripesGenerator stripesGenerator)
        {
            _appDataService = appDataService;
            _stripesGenerator = stripesGenerator;
                      
            GenerateStripesCommand = new Command(GetStripes);
        }
        
        private void GetStripes()
        {
            try
            {
                Stripes = _stripesGenerator.GenerateStripes(RandomStripes);
            }
            catch(Exception ex)
            {

            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters == null || parameters["random"] == null)
            {
                RandomStripes = false;
            }
            else
            {
                RandomStripes = bool.Parse(parameters["random"].ToString());
            }

            try
            {
                Stripes = _stripesGenerator.GenerateStripes(RandomStripes);
            }
            catch(Exception ex)
            {
                // show dialog?
            }

        }
    }
}

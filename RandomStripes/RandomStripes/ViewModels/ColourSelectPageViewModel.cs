using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomStripes.ViewModels
{
	public class ColourSelectPageViewModel : ViewModelBase
	{
       
        public ColourSelectPageViewModel(INavigationService navigationService)
         : base(navigationService)
        {
            Title = "Colour Selection";

           // NextCommand = new Command(NextPage);
        }

    }
}

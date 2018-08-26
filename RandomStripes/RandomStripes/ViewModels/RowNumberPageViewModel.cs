using Prism.Navigation;
using Prism.Services;
using RandomStripes.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomStripes.ViewModels
{
    public class RowNumberPageViewModel : ViewModelBase
	{
        private readonly IPageDialogService _dialogService;

        public ICommand NextCommand { get; set; }

        public RowNumberPageViewModel(INavigationService navigationService, IAppDataService appDataService, IPageDialogService dialogService)
            : base(navigationService, appDataService)
        {
            Title = "Row Number";
            _dialogService = dialogService;

            NextCommand = new Command<string>(NextPage);
        }

        public void NextPage(string rows)
        {
            if(string.IsNullOrEmpty(rows))
            {
                _dialogService.DisplayAlertAsync("", "Oops, please enter a number of rows", "Ok");
                return;
            }

            int rowsCount;
            var rowsValid = int.TryParse(rows, out rowsCount);
            if (!rowsValid)
            {
                _dialogService.DisplayAlertAsync("", "Oops something went wrong, please enter a valid number", "Ok");
                return;
            }

            _appDataService.RowCount = rowsCount;
            NavigationService.NavigateAsync("RowHeightsPage");
        }
    }
}

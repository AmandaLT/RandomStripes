using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStripes.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IAppDataService _appDataService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IAppDataService appDataService)
        {
            NavigationService = navigationService;
            _appDataService = appDataService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}

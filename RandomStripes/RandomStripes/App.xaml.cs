﻿using Prism;
using Prism.Ioc;
using RandomStripes.ViewModels;
using RandomStripes.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using RandomStripes.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RandomStripes
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<RowNumberPage>();
            containerRegistry.RegisterForNavigation<RowHeightsPage>();
            containerRegistry.RegisterForNavigation<ColourSelectPage>();
            containerRegistry.RegisterForNavigation<CustomColourSelectPage>();
            containerRegistry.RegisterForNavigation<PaletteColourSelectPage>();

            containerRegistry.Register<IAppDataService, AppDataService>();
            containerRegistry.Register<IColoursService, ColoursInMemoryService>();
            containerRegistry.Register<IStripesGenerator, StripesGenerator>();
            containerRegistry.Register<IApplicationWrapper, ApplicationWrapper>();

            containerRegistry.RegisterForNavigation<StripesPage>();
        }
    }
}

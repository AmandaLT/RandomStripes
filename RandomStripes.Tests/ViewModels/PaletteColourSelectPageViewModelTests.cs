using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using RandomStripes.Services;
using RandomStripes.ViewModels;

namespace RandomStripes.Tests.ViewModels
{
    [TestClass]
    public class PaletteColourSelectPageViewModelTests
    {
        private Mock<INavigationService> _navigationService;
        private Mock<IAppDataService> _appDataService;
        private Mock<IPageDialogService> _dialogService;
        private Mock<IColoursService> _coloursService;

        private PaletteColourSelectPageViewModel model;

        [TestInitialize]
        public void Setup()
        {
            _navigationService = new Mock<INavigationService>();
            _appDataService = new Mock<IAppDataService>();
            _dialogService = new Mock<IPageDialogService>();
            _coloursService = new Mock<IColoursService>();

            _coloursService.Setup(c => c.GetColourPalettes()).Returns(new System.Collections.Generic.List<ColourPalette>
            {
                new ColourPalette()
            });

            model = new PaletteColourSelectPageViewModel(_navigationService.Object, _appDataService.Object, _dialogService.Object, _coloursService.Object);

        }


        [TestMethod]
        public void PaletteSelect_NoInitialSelectedPalette_SelectedPalette_SetTrue()
        {
            var selectedPalette = new ColourPalette { IsSelected = false };
            model.PaletteSelect(selectedPalette);

            Assert.IsTrue(selectedPalette.IsSelected);
        }

        [TestMethod]
        public void PaletteSelect_CurrentPaletteDeselected_SelectedPalette_SetTrue()
        {
            var currentPalette = new ColourPalette { IsSelected = false };
            model.PaletteSelect(currentPalette);

            var selectedPalette = new ColourPalette { IsSelected = false };
            model.PaletteSelect(selectedPalette);

            Assert.IsTrue(selectedPalette.IsSelected);
            Assert.IsFalse(currentPalette.IsSelected);
        }

        [TestMethod]
        public void NextPage_NoPaletteSelected_DisplayDialog_AndDoesntNavigateToNextPage()
        {
            _dialogService.Setup(d => d.DisplayAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            model.NextPage("aStripeType");

            _dialogService.Verify(d => d.DisplayAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void NextPage_PaletteSelected_RandomStripeType_NavigateToNextPage_RandomParamTrue()
        {
            _navigationService.Setup(n => n.NavigateAsync(It.IsAny<string>()));
            _appDataService.Setup(a => a.SelectedColours);

            var selectedPalette = new ColourPalette();
            model.PaletteSelect(selectedPalette);
            model.NextPage("random");

            _navigationService.Verify(n => n.NavigateAsync("StripesPage?random=True"), Times.Once);
        }

        [TestMethod]
        public void NextPage_PaletteSelected_NotRandomStripeType_NavigateToNextPage_RandomParamFalse()
        {
            _navigationService.Setup(n => n.NavigateAsync(It.IsAny<string>()));
            _appDataService.Setup(a => a.SelectedColours);

            var selectedPalette = new ColourPalette();
            model.PaletteSelect(selectedPalette);
            model.NextPage("notRandom");

            _navigationService.Verify(n => n.NavigateAsync("StripesPage?random=False"), Times.Once);
        }

    }
}

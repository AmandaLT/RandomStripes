using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using RandomStripes.Models;
using RandomStripes.Services;
using RandomStripes.ViewModels;
using System.Collections.Generic;

namespace RandomStripes.Tests.ViewModels
{
    [TestClass]
    public class CustomColourSelectPageViewModelTests
    {
        private Mock<IColoursService> _coloursService;
        private Mock<INavigationService> _navigationService;
        private Mock<IAppDataService> _appDataService;
        private Mock<IPageDialogService> _dialogService;

        private CustomColourSelectPageViewModel model;

        [TestInitialize]
        public void Setup()
        {
            _coloursService = new Mock<IColoursService>();
            _navigationService = new Mock<INavigationService>();
            _appDataService = new Mock<IAppDataService>();
            _dialogService = new Mock<IPageDialogService>();
        }

        [TestMethod]
        public void Model_SetupWithColours()
        {
            _coloursService.Setup(c => c.GetColours()).Returns(
                new List<ColourItem>
            {
                    new ColourItem()
            });

            model = new CustomColourSelectPageViewModel(_navigationService.Object, _appDataService.Object, _coloursService.Object, _dialogService.Object);

            Assert.IsTrue(model.Colours.Count > 0);
            _coloursService.Verify(c => c.GetColours(), Times.Once);
        }

        [TestMethod]
        public void ColourSelect_SelectedColour_IsUnselected()
        {
            model = new CustomColourSelectPageViewModel(_navigationService.Object, _appDataService.Object, _coloursService.Object, _dialogService.Object);

            ColourItem selectedColourItem = new ColourItem { ColourData = "hex", IsSelected = true, Name = "SelectedColour" };
            model.Colours = new List<ColourItem>
            {
                selectedColourItem,
                new ColourItem{ ColourData = "hex1", IsSelected=false, Name="UnSelectedColour" },
                new ColourItem{ ColourData = "hex2", IsSelected=false, Name="UnSelectedColour2" },
            };

            model.ColourSelect(selectedColourItem);

            Assert.IsFalse(selectedColourItem.IsSelected);
        }

        [TestMethod]
        public void NextPage_NoColoursSelected_DisplaysDialog_DoesntNavigateToNextPage()
        {
            _coloursService.Setup(c => c.GetColours()).Returns(new List<ColourItem>
            {
                new ColourItem{ IsSelected = false },
                new ColourItem{ IsSelected = false },
                new ColourItem{ IsSelected = false },
            });

            _dialogService.Setup(d => d.DisplayAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            model = new CustomColourSelectPageViewModel(_navigationService.Object, _appDataService.Object, _coloursService.Object, _dialogService.Object);

            model.NextPage("aStripeType");

            _dialogService.Verify(d => d.DisplayAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _navigationService.Verify(n => n.NavigateAsync(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void NextPage_ColoursSelected_RandomStripesSelected_NavigateToNextPage_WithRandomTrue()
        {
            _coloursService.Setup(c => c.GetColours()).Returns(new List<ColourItem>
            {
                new ColourItem{ IsSelected = true },
            });

            _navigationService.Setup(n => n.NavigateAsync(It.IsAny<string>()));
            _appDataService.Setup(a => a.SelectedColours);

            model = new CustomColourSelectPageViewModel(_navigationService.Object, _appDataService.Object, _coloursService.Object, _dialogService.Object);

            model.NextPage("random");
            
            _navigationService.Verify(n => n.NavigateAsync("StripesPage?random=True"), Times.Once);
        }

        [TestMethod]
        public void NextPage_ColoursSelected_NotRandomStripesSelected_NavigateToNextPage_WithRandomFalse()
        {
            _coloursService.Setup(c => c.GetColours()).Returns(new List<ColourItem>
            {
                new ColourItem{ IsSelected = true },
            });

            _navigationService.Setup(n => n.NavigateAsync(It.IsAny<string>()));
            _appDataService.Setup(a => a.SelectedColours);

            model = new CustomColourSelectPageViewModel(_navigationService.Object, _appDataService.Object, _coloursService.Object, _dialogService.Object);

            model.NextPage("notRandom");

            _navigationService.Verify(n => n.NavigateAsync("StripesPage?random=False"), Times.Once);
        }
    }
}

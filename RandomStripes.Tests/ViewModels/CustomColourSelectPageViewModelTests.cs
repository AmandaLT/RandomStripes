using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
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

        private CustomColourSelectPageViewModel model;

        [TestInitialize]
        public void Setup()
        {
            _coloursService = new Mock<IColoursService>();
            _navigationService = new Mock<INavigationService>();
            _appDataService = new Mock<IAppDataService>();

            
        }

        [TestMethod]
        public void Model_SetupWithColours()
        {
            _coloursService.Setup(c => c.GetColours()).Returns(
                new List<ColourItem>
            {
                    new ColourItem()
            });

            model = new CustomColourSelectPageViewModel(_navigationService.Object, _appDataService.Object, _coloursService.Object);

            Assert.IsTrue(model.Colours.Count > 0);
            _coloursService.Verify(c => c.GetColours(), Times.Once);
        }

        [TestMethod]
        public void ColourSelect_SelectedColour_IsUnselected()
        {
            model = new CustomColourSelectPageViewModel(_navigationService.Object, _appDataService.Object, _coloursService.Object);

            ColourItem selectedColourItem = new ColourItem { ColourData = new Xamarin.Forms.Color(), IsSelected = true, Name = "SelectedColour" };
            model.Colours = new List<ColourItem>
            {
                selectedColourItem,
                new ColourItem{ ColourData = new Xamarin.Forms.Color(), IsSelected=false, Name="UnSelectedColour" },
                new ColourItem{ ColourData = new Xamarin.Forms.Color(), IsSelected=false, Name="UnSelectedColour2" },
            };

            model.ColourSelect(selectedColourItem);

            Assert.IsFalse(selectedColourItem.IsSelected);
        }
    }
}

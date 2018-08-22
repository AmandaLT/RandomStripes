using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using RandomStripes.Services;
using RandomStripes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStripes.Tests.ViewModels
{
    [TestClass]
    public class ColourSelectPageViewModelTests
    {
        private Mock<INavigationService> _navigationService;
        private Mock<IAppDataService> _appDataService;
        private ColourSelectPageViewModel model;

        [TestInitialize]
        public void Setup()
        {
            _navigationService = new Mock<INavigationService>();
            _appDataService = new Mock<IAppDataService>();
            _appDataService.Setup(a => a.RowCount).Returns(54);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1, 2 });

            model = new ColourSelectPageViewModel(_navigationService.Object, _appDataService.Object);
        }

        [TestMethod]
        public void NextPage_CustomColourSelect_NavigatesToCustomColourSelectPage()
        {            
            _navigationService.Setup(n => n.NavigateAsync(It.IsAny<string>()));

            model.NextPage("custom");

            _navigationService.Verify(n => n.NavigateAsync("CustomColourSelectPage"), Times.Once);
        }

        [TestMethod]
        public void NextPage_NotCustomColourSelect_NavigatesToPaletteColourSelectPage()
        {
            _navigationService.Setup(n => n.NavigateAsync(It.IsAny<string>()));

            model.NextPage("not_custom");

            _navigationService.Verify(n => n.NavigateAsync("PaletteColourSelectPage"), Times.Once);
        }
    }
}

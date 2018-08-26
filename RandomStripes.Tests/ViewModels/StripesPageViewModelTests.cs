using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RandomStripes.Services;
using RandomStripes.ViewModels;
using System.Collections.Generic;

namespace RandomStripes.Tests.ViewModels
{
    [TestClass]
    public class StripesPageViewModelTests
    {
        private Mock<IAppDataService> _appDataService;
        private Mock<IStripesGenerator> _stripesGenerator;
        private StripesPageViewModel model;

        [TestInitialize]
        public void Setup()
        {
            _appDataService = new Mock<IAppDataService>();
            _stripesGenerator = new Mock<IStripesGenerator>();

            _appDataService.Setup(a => a.SelectedColours).Returns(new List<ColourItem>());

            model = new StripesPageViewModel(_appDataService.Object, _stripesGenerator.Object);
        }

        [TestMethod]
        public void OnNavigatingTo_NoNavParameters_SavesNonRandomFlag()
        {
            _stripesGenerator.Setup(s => s.GenerateStripes(It.IsAny<bool>()));

            model.OnNavigatingTo(null);

            Assert.IsFalse(model.RandomStripes);
            _stripesGenerator.Verify(s => s.GenerateStripes(false), Times.Once);
        }

        [TestMethod]
        public void OnNavigatingTo_NoRandomFlagParameter_SavesNonRandomFlag()
        {
            _stripesGenerator.Setup(s => s.GenerateStripes(It.IsAny<bool>()));

            model.OnNavigatingTo(new Prism.Navigation.NavigationParameters());

            Assert.IsFalse(model.RandomStripes);
            _stripesGenerator.Verify(s => s.GenerateStripes(false), Times.Once);
        }

        [TestMethod]
        public void OnNavigatingTo_NotRandomParameter_SavesNotRandomFlag()
        {
            _stripesGenerator.Setup(s => s.GenerateStripes(It.IsAny<bool>()));

            var navParams = new Prism.Navigation.NavigationParameters
            {
                {"random", false }
            };

            model.OnNavigatingTo(navParams);

            Assert.IsFalse(model.RandomStripes);
            _stripesGenerator.Verify(s => s.GenerateStripes(false), Times.Once);
        }

        [TestMethod]
        public void OnNavigatingTo_RandomParameter_SavesRandomFlag()
        {
            _stripesGenerator.Setup(s => s.GenerateStripes(It.IsAny<bool>()));

            var navParams = new Prism.Navigation.NavigationParameters
            {
                {"random", true }
            };

            model.OnNavigatingTo(navParams);

            Assert.IsTrue(model.RandomStripes);
            _stripesGenerator.Verify(s => s.GenerateStripes(true), Times.Once);
        }
    }
}

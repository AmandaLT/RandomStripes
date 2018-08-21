using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using RandomStripes.Services;
using RandomStripes.ViewModels;

namespace RandomStripes.Tests.ViewModels
{
    [TestClass]
    public class RowHeightsPageViewModelTests
    {
        private RowHeightsPageViewModel model;
        private Mock<INavigationService> _navigationService;
        private Mock<IAppDataService> _appDataService;
        private Mock<IPageDialogService> _dialogService;

        [TestInitialize]
        public void SetUp()
        {
            _navigationService = new Mock<INavigationService>();
            _appDataService = new Mock<IAppDataService>();
            _dialogService = new Mock<IPageDialogService>();
            model = new RowHeightsPageViewModel(_navigationService.Object, _appDataService.Object, _dialogService.Object);
        }

        [TestMethod]
        public void NextPage_NoHeightsSelected_DisplayAlert()
        {
            _dialogService.Setup(d => d.DisplayAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            model.rowHeights.Clear();
            model.NextPage();

            _dialogService.Verify(d => d.DisplayAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void NextPage_HeightsSelected_NavigateToColourSelectPage()
        {
            _navigationService.Setup(n => n.NavigateAsync(It.IsAny<string>()));

            model.rowHeights.Add(1);
            model.NextPage();

            _navigationService.Verify(n => n.NavigateAsync(It.IsAny<string>()), Times.Once);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using RandomStripes.Services;
using RandomStripes.ViewModels;

namespace RandomStripes.Tests.ViewModels
{
    [TestClass]
    public class RowNumberPageViewModelTests
    {
        private RowNumberPageViewModel model;
        private Mock<INavigationService> _navigationService;
        private Mock<IAppDataService> _appDataService;
        private Mock<IPageDialogService> _dialogService;

        [TestInitialize]
        public void SetUp()
        {
            _navigationService = new Mock<INavigationService>();
            _appDataService = new Mock<IAppDataService>();
            _dialogService = new Mock<IPageDialogService>();
            model = new RowNumberPageViewModel(_navigationService.Object, _appDataService.Object, _dialogService.Object);
        }

        [TestMethod]
        public void NextPage_NoRowsEntered_ShowsAlert()
        {
            _dialogService.Setup(d =>
                d.DisplayAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            model.NextPage(string.Empty);

            _dialogService.Verify(d =>
                           d.DisplayAlertAsync(It.IsAny<string>(), "Oops, please enter a number of rows", It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void NextPage_InvalidInputRowsEntered_ShowsAlert()
        {
            _dialogService.Setup(d =>
               d.DisplayAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            model.NextPage("notanumber");

            _dialogService.Verify(d =>
                           d.DisplayAlertAsync(It.IsAny<string>(), "Oops something went wrong, please enter a valid number", It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void NextPage_RowsEntered_NavigateToColourSelectPage()
        {
            _navigationService.Setup(n => n.NavigateAsync(It.IsAny<string>()));
            _appDataService.Setup(a => a.RowCount);

            model.NextPage("23");

            _navigationService.Verify(n => n.NavigateAsync("ColourSelectPage"), Times.Once);
        }
    }
}

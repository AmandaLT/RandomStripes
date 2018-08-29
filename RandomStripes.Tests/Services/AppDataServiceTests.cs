using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RandomStripes.Services;
using RandomStripes.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RandomStripes.Tests.Services
{
    [TestClass]
    public class AppDataServiceTests
    {
        private AppDataService _appDataService;
        private Mock<IApplicationWrapper> _applicationWrapper;

        [TestInitialize]
        public void Setup()
        {
            _applicationWrapper = new Mock<IApplicationWrapper>();
            _appDataService = new AppDataService(_applicationWrapper.Object);
        }

        [TestMethod]
        public void RowCount_Get_NoRowCountSaved_Returns_Zero()
        {
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string,object>());
            var result = _appDataService.RowCount;

            Assert.AreEqual(0, result);
        }

        [TestMethod]        
        public void RowCount_Get_ZeroRowCountSaved_Returns_Zero()
        {
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string, object>()
            {
               {"RowCount", 0}
            });
            var result = _appDataService.RowCount;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void RowCount_Get_RowCountSaved_Returns_CorrectCount()
        {
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string, object>()
            {
               {"RowCount", 34}
            });
            var result = _appDataService.RowCount;

            Assert.AreEqual(34, result);
        }

        [TestMethod]
        public void RowHeights_Get_NoRowHeightSaved_Returns_EmptyList()
        {
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string, object>());
            var result = _appDataService.RowHeights;

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void RowHeights_Get_OneRowHeightSaved_Returns_ListWithOneHeight()
        {
            var rowHeight = new List<int>
            {
                2
            };
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string, object>()
            {
                {"RowHeights", JsonConvert.SerializeObject(rowHeight)}
            });
            var result = _appDataService.RowHeights;

            Assert.AreEqual(1, result.Count);
        }


        [TestMethod]
        public void RowHeights_Get_MultipleRowHeightsSaved_Returns_ListOfHeights()
        {
            var rowHeights = new List<int>
            {
                2,6,9
            };
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string, object>()
            {
                {"RowHeights", JsonConvert.SerializeObject(rowHeights)}
            });
            var result = _appDataService.RowHeights;

            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.Contains(2));
            Assert.IsTrue(result.Contains(6));
            Assert.IsTrue(result.Contains(9));
        }

        [TestMethod]
        public void SelectedColours_Get_NoColoursSaved_ReturnsEmptyList()
        {
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string, object>());
            var result = _appDataService.SelectedColours;

            Assert.AreEqual(0, result.Count);
        }


        [TestMethod]
        public void SelectedColours_Get_OneColourSaved_ReturnsListWithOneColour()
        {
            var selectedColours = new List<ColourItem>
            {
                new ColourItem{ Name="colour1" }
            };
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string, object>()
            {
                {"SelectedColours", JsonConvert.SerializeObject(selectedColours)}
            });
            var result = _appDataService.SelectedColours;

            Assert.AreEqual(1, result.Count);
            Assert.IsNotNull(result.First(c =>c.Name == "colour1"));
        }

        [TestMethod]
        public void SelectedColours_Get_sColourSaved_ReturnsListWithColours()
        {
            var selectedColours = new List<ColourItem>
            {
                new ColourItem{ Name="colour1" },
                new ColourItem{ Name="colour2" }
            };
            _applicationWrapper.Setup(a => a.Properties).Returns(new Dictionary<string, object>()
            {
                {"SelectedColours", JsonConvert.SerializeObject(selectedColours)}
            });
            var result = _appDataService.SelectedColours;

            Assert.AreEqual(2, result.Count);
            Assert.IsNotNull(result.First(c => c.Name == "colour1"));
            Assert.IsNotNull(result.First(c => c.Name == "colour2"));
        }
    }
}

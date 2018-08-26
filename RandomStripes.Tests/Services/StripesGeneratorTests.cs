using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RandomStripes.Models;
using RandomStripes.Services;
using RandomStripes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStripes.Tests.Services
{
    [TestClass]
    public class StripesGeneratorTests
    {
        private Mock<IAppDataService> _appDataService;
        private StripesGenerator _stripesGenerator;

        [TestInitialize]
        public void Setup()
        {
            _appDataService = new Mock<IAppDataService>();
            _stripesGenerator = new StripesGenerator(_appDataService.Object);
        }

        [TestMethod]
        public void GenerateStripes_NoRowCount_ReturnsEmptyList()
        {
            _appDataService.Setup(a => a.RowCount).Returns(0);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1 });
            _appDataService.Setup(a => a.SelectedColours).Returns(new List<ColourItem> { new ColourItem(), new ColourItem(), new ColourItem(), new ColourItem(), new ColourItem() });

            var result = _stripesGenerator.GenerateStripes(false);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void GenerateStripes_NoSelectedColours_ReturnsEmptyList()
        {
            _appDataService.Setup(a => a.RowCount).Returns(10);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1 });
            _appDataService.Setup(a => a.SelectedColours).Returns(new List<ColourItem>());

            var result = _stripesGenerator.GenerateStripes(false);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void GenerateStripes_NotRandom_OneSelectedColours_CreatesRepeatingStripes_OfTotalRows()
        {
            var rowCount = 6;
            _appDataService.Setup(a => a.RowCount).Returns(rowCount);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1 });
            _appDataService.Setup(a => a.SelectedColours).Returns(new List<ColourItem> {
                new ColourItem{ Name="Colour1" } });

            var result = _stripesGenerator.GenerateStripes(false);

            Assert.AreEqual(rowCount, result.Count);
            Assert.AreEqual("Colour1", result.ElementAt(0).Name);
            Assert.AreEqual("Colour1", result.ElementAt(1).Name);
            Assert.AreEqual("Colour1", result.ElementAt(2).Name);
            Assert.AreEqual("Colour1", result.ElementAt(3).Name);
            Assert.AreEqual("Colour1", result.ElementAt(4).Name);
            Assert.AreEqual("Colour1", result.ElementAt(5).Name);
        }

        [TestMethod]
        public void GenerateStripes_NotRandom_MoreTotalRowsThanSelectedColours_ReturnsCorrectNumber_OfTotalRows()
        {
            var rowCount = 15;
            _appDataService.Setup(a => a.RowCount).Returns(rowCount);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1 });
            _appDataService.Setup(a => a.SelectedColours).Returns(new List<ColourItem> { new ColourItem(), new ColourItem(), new ColourItem(),new ColourItem(), new ColourItem() });

            var result = _stripesGenerator.GenerateStripes(false);

            Assert.AreEqual(rowCount, result.Count);
        }

        [TestMethod]
        public void GenerateStripes_NotRandom_LessTotalRowsThansSelectedColours_CreatesOrderedStripes_OfTotalRows()
        {
            var rowCount = 3;
            _appDataService.Setup(a => a.RowCount).Returns(rowCount);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1 });
            _appDataService.Setup(a => a.SelectedColours).Returns(new List<ColourItem> {
                new ColourItem{ Name="Colour1" }, new ColourItem{ Name="Colour2" }, new ColourItem{ Name="Colour3" }, new ColourItem{ Name="Colour4" } });

            var result = _stripesGenerator.GenerateStripes(false);

            Assert.AreEqual(rowCount, result.Count);
            Assert.AreEqual("Colour1", result.ElementAt(0).Name);
            Assert.AreEqual("Colour2", result.ElementAt(1).Name);
            Assert.AreEqual("Colour3", result.ElementAt(2).Name);
        }

        [TestMethod]
        public void GenerateStripes_NotRandom_MoreTotalRowsThanSelectedColours_CreatesRepeatingOrderedStripes_OfTotalRows()
        {
            var rowCount = 6;
            _appDataService.Setup(a => a.RowCount).Returns(rowCount);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1 });
            _appDataService.Setup(a => a.SelectedColours).Returns(new List<ColourItem> {
                new ColourItem{ Name="Colour1" }, new ColourItem{ Name="Colour2" }, new ColourItem{ Name="Colour3" } });

            var result = _stripesGenerator.GenerateStripes(false);

            Assert.AreEqual(rowCount, result.Count);
            Assert.AreEqual("Colour1", result.ElementAt(0).Name);
            Assert.AreEqual("Colour2", result.ElementAt(1).Name);
            Assert.AreEqual("Colour3", result.ElementAt(2).Name);
            Assert.AreEqual("Colour1", result.ElementAt(3).Name);
            Assert.AreEqual("Colour2", result.ElementAt(4).Name);
            Assert.AreEqual("Colour3", result.ElementAt(5).Name);
        }

        [TestMethod]
        public void GenerateStripes_Random_CreatesRandomStripes_OfTotalRows_ContainingAllSelectedColours()
        {
            var rowCount = 7;
            var selectedColours = new List<ColourItem> {
                new ColourItem{ Name="Colour1" }, new ColourItem{ Name="Colour2" }, new ColourItem{ Name="Colour3" } };

            _appDataService.Setup(a => a.RowCount).Returns(rowCount);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1 });
            _appDataService.Setup(a => a.SelectedColours).Returns(selectedColours);

            var result = _stripesGenerator.GenerateStripes(true);

            Assert.AreEqual(rowCount, result.Count);
                        
            var generatedStripe1IsSameColourAsSelectedColour1 = result.ElementAt(0).Name == selectedColours.ElementAt(0).Name;
            var generatedStripe2IsSameColourAsSelectedColour2 = result.ElementAt(1).Name == selectedColours.ElementAt(1).Name;
            var generatedStripe3IsSameColourAsSelectedColour3 = result.ElementAt(2).Name == selectedColours.ElementAt(2).Name;
            var generatedStripe4IsSameColourAsSelectedColour4 = result.ElementAt(3).Name == selectedColours.ElementAt(0).Name;
            var generatedStripe5IsSameColourAsSelectedColour5 = result.ElementAt(4).Name == selectedColours.ElementAt(1).Name;
            var generatedStripe6IsSameColourAsSelectedColour6 = result.ElementAt(5).Name == selectedColours.ElementAt(2).Name;
            var generatedStripe7IsSameColourAsSelectedColour7 = result.ElementAt(6).Name == selectedColours.ElementAt(0).Name;

            var stripesAreRandom = (generatedStripe1IsSameColourAsSelectedColour1 &&
                generatedStripe2IsSameColourAsSelectedColour2 &&
                generatedStripe3IsSameColourAsSelectedColour3 &&
                generatedStripe4IsSameColourAsSelectedColour4 &&
                generatedStripe5IsSameColourAsSelectedColour5 &&
                generatedStripe6IsSameColourAsSelectedColour6 &&
                generatedStripe7IsSameColourAsSelectedColour7) == false;

            Assert.IsTrue(stripesAreRandom, "Stripes are random");

            Assert.IsTrue(result.Contains(selectedColours.ElementAt(0)));
            Assert.IsTrue(result.Contains(selectedColours.ElementAt(1)));
            Assert.IsTrue(result.Contains(selectedColours.ElementAt(2)));

        }

        [TestMethod]
        public void GenerateStripes_Random_CreatesRandomStripes_OfTotalRows_NoSameConsecutiveRows()
        {
            var rowCount = 4;
            var selectedColours = new List<ColourItem> {
                new ColourItem{ Name="Colour1" }, new ColourItem{ Name="Colour2" }, new ColourItem{ Name="Colour3" } };

            _appDataService.Setup(a => a.RowCount).Returns(rowCount);
            _appDataService.Setup(a => a.RowHeights).Returns(new List<int> { 1 });
            _appDataService.Setup(a => a.SelectedColours).Returns(selectedColours);

            var result = _stripesGenerator.GenerateStripes(true);

            Assert.AreEqual(rowCount, result.Count);

            var resultStripe1Name = result.ElementAt(0).Name;
            var resultStripe2Name = result.ElementAt(1).Name;
            var resultStripe3Name = result.ElementAt(2).Name;
            var resultStripe4Name = result.ElementAt(3).Name;

            var generatedStripe1IsSameColourAsSelectedColour1 = resultStripe1Name == selectedColours.ElementAt(0).Name;
            var generatedStripe2IsSameColourAsSelectedColour2 = resultStripe2Name == selectedColours.ElementAt(1).Name;
            var generatedStripe3IsSameColourAsSelectedColour3 = resultStripe3Name == selectedColours.ElementAt(2).Name;
            var generatedStripe4IsSameColourAsSelectedColour4 = resultStripe4Name == selectedColours.ElementAt(0).Name;
           
            var stripesAreRandom = (generatedStripe1IsSameColourAsSelectedColour1 &&
                generatedStripe2IsSameColourAsSelectedColour2 &&
                generatedStripe3IsSameColourAsSelectedColour3 &&
                generatedStripe4IsSameColourAsSelectedColour4) == false;

            Assert.IsTrue(stripesAreRandom, "Stripes should be random");

            //Assert.IsTrue(result.Contains(selectedColours.ElementAt(0)), "Stripes should contain Colour1");
            //Assert.IsTrue(result.Contains(selectedColours.ElementAt(1)), "Stripes should contain Colour2");
            //Assert.IsTrue(result.Contains(selectedColours.ElementAt(2)), "Stripes should contain Colour3");

            Assert.IsTrue(resultStripe1Name != resultStripe2Name, "Stripe1 shouldn't be the same as Stripe2");
            Assert.IsTrue(resultStripe2Name != resultStripe3Name, "Stripe2 shouldn't be the same as Stripe3");
            Assert.IsTrue(resultStripe3Name != resultStripe4Name, "Stripe3 shouldn't be the same as Stripe4");
        }
    }
}

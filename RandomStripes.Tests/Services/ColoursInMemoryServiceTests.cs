using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomStripes.Services;
using RandomStripes.ViewModels;

namespace RandomStripes.Tests
{
    [TestClass]
    public class ColoursInMemoryServiceTests
    {
        private ColoursInMemoryService _service;

        [TestInitialize]
        public void SetUp()
        {
            _service = new ColoursInMemoryService();
        }

        [TestMethod]
        public void GetColours_ReturnsAllColours()
        {
            var result = _service.GetColours();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetColourPalettes_ReturnsListOfColourItems()
        {
            var result = _service.GetColourPalettes();

            Assert.IsTrue(result.Count > 0);
            Assert.IsInstanceOfType(result[1].Colours[1], typeof(ColourItem));
        }
    }
}

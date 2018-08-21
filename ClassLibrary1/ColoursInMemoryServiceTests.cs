using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomStripes.Services;
using System;

namespace RandomStripes.Test
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

            Assert.AreEqual(12, result.Count);
        }
    }
}

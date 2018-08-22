using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomStripes.Services;

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
    }
}

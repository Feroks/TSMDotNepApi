using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSMModels.NotificationModels.Price;

namespace TSMConsole.Tests
{
    [TestClass]
    public class TsmPriceTests
    {
        [TestMethod]
        public void TsmPriceTest1()
        {
            var value = string.Empty;
            for (var i = 1; i < 10; i++)
            {
                value += i;
                Assert.AreEqual(new TsmPrice(int.Parse(value)).Total.ToString(), value);
            }
        }

        [TestMethod]
        public void TsmPriceTest2()
        {
            Assert.AreEqual(new TsmPrice(20928200000).Total, 20928200000);
        }

        [TestMethod]
        public void TsmPriceTest3()
        {
            Assert.AreEqual(new TsmPrice(50000000).StringifiedValue, "5000g 00s 00c");
        }

        [TestMethod]
        public void TsmPriceTest4()
        {
            Assert.AreEqual(new TsmPrice(121231001).StringifiedValue, "12123g 10s 01c");
        }

        [TestMethod]
        public void TsmPriceTest5()
        {
            Assert.AreEqual(new TsmPrice(5000000).StringifiedValue, "500g 00s 00c");
        }

        [TestMethod]
        public void TsmPriceTest6()
        {
            Assert.AreEqual(TsmPrice.FromGold(1).StringifiedValue, "1g 00s 00c");
        }

        [TestMethod]
        public void TsmPriceTest7()
        {
            Assert.AreEqual(TsmPrice.FromGold(12).StirngifiedValueGoldOnly, "12g");
        }
    }
}
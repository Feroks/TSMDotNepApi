using TSMDotNetApi.Models.Price;
using Xunit;

namespace TSMDotNetApi.Tests
{
    public class TsmPriceTests
    {
        [Fact]
        public void TsmPriceTest1()
        {
            var value = string.Empty;
            for (var i = 1; i < 10; i++)
            {
                value += i;
                Assert.Equal(new TsmPrice(int.Parse(value)).Total.ToString(), value);
            }
        }

        [Fact]
        public void TsmPriceTest2()
        {
            Assert.Equal(20928200000, new TsmPrice(20928200000).Total);
        }

        [Fact]
        public void TsmPriceTest3()
        {
            Assert.Equal("5 000g 00s 00c", new TsmPrice(50000000).StringifiedValue);
        }

        [Fact]
        public void TsmPriceTest4()
        {
            Assert.Equal("12 123g 10s 01c", new TsmPrice(121231001).StringifiedValue);
        }

        [Fact]
        public void TsmPriceTest5()
        {
            Assert.Equal("500g 00s 00c", new TsmPrice(5000000).StringifiedValue);
        }

        [Fact]
        public void TsmPriceTest6()
        {
            Assert.Equal("1g 00s 00c", TsmPrice.FromGold(1).StringifiedValue);
        }

        [Fact]
        public void TsmPriceTest7()
        {
            Assert.Equal("12g", TsmPrice.FromGold(12).StirngifiedValueGoldOnly);
        }

        [Fact]
        public void TsmPriceTest8()
        {
            var price = new TsmPrice(1000);

            // Set new value
            price.Total = 1234;

            Assert.Equal(0, price.Gold.Value);
            Assert.Equal(12, price.Silver.Value);
            Assert.Equal(34, price.Copper.Value);
        }
    }
}
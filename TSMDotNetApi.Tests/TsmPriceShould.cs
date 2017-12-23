using TSMDotNetApi.Models.Price;
using Xunit;

namespace TSMDotNetApi.Tests
{
    public class TsmPriceShould
    {
        [Fact]
        public void CalculateTotalCorrectly()
        {
            Assert.Equal(20928200000, new TsmPrice(20928200000).Total);
        }

        [Theory]
        [InlineData(50000000, "5 000g 00s 00c")]
        [InlineData(121231001, "12 123g 10s 01c")]
        [InlineData(5000000, "500g 00s 00c")]
        public void StringifyValueCorrectly(long value, string result)
        {
            Assert.Equal(result, new TsmPrice(value).StringifiedValue);
        }

        [Theory]
        [InlineData(1, "1g 00s 00c")]
        [InlineData(12, "12g 00s 00c")]
        public void InitializeFromGoldCorrectly(long value, string result)
        {
            Assert.Equal(result, TsmPrice.FromGold(value).StringifiedValue);
        }

        [Fact]
        public void SupportPriceChange()
        {
            var data = new TsmPrice(0);

            data.Total = 12345;

            Assert.Equal(12345, data.Total);
            Assert.Equal(1, data.Gold.Value);
            Assert.Equal(23, data.Silver.Value);
            Assert.Equal(45, data.Copper.Value);
        }
    }
}
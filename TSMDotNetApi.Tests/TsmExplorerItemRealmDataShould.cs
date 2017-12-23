using System.Threading.Tasks;
using TSMDotNetApi.Enums;
using TSMDotNetApi.Exceptions;
using TSMDotNetApi.Tests.Properties;
using Xunit;

namespace TSMDotNetApi.Tests
{
    public class TsmExplorerItemRealmDataShould
    {
        private static ITsmExplorer _tsmExplorer;
        private static readonly string ApiKey = Resources.ApiKey;
        public static string RealmName { get; } = "Razuvious";

        public TsmExplorerItemRealmDataShould()
        {
            _tsmExplorer = new TsmExplorer(ApiKey);
        }

        [Fact]
        public async Task GetDataForValidItemId()
        {
            var data = await _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, "Twisting Nether", 31336);

            Assert.Equal("Blade of Wizardry", data.Name);
            Assert.Equal("Weapon", data.Class);
            Assert.Equal("Sword", data.SubClass);
            Assert.Equal(31336, data.Id);
            Assert.Equal(0, data.VendorBuy.Total);
            Assert.Equal(432949, data.VendorSell.Total);
            Assert.Equal(100, data.Level);
        }

        [Fact]
        public async Task ThrowExceptionIfItemNotFound()
        {
            await Assert.ThrowsAsync<TsmFailedException>(() => _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, RealmName, -1));
        }
    }
}

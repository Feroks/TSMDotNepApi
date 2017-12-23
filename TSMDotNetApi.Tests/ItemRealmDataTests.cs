using System;
using System.Threading;
using System.Threading.Tasks;
using TSMDotNetApi.Enums;
using TSMDotNetApi.Exceptions;
using TSMDotNetApi.Models;
using TSMDotNetApi.Tests.Properties;
using Xunit;

namespace TSMDotNetApi.Tests
{
    public class ItemRealmDataTests
    {
        private static ITsmExplorer _tsmExplorer;
        private static readonly string ApiKey = Resources.ApiKey;
        public static string RealmName { get; } = "Razuvious";

        public ItemRealmDataTests()
        {
            _tsmExplorer = new TsmExplorer(ApiKey);
        }

        [Fact]
        public async Task GetItemRealmData_31336()
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
        public async Task GetItemRealmData_Exception()
        {
            await Assert.ThrowsAsync<TsmFailedException>(() => _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, RealmName, -1));
        }

        [Fact]
        public async Task GetItemRealmData_CancelTask_Automatically()
        {
            var cs = new CancellationTokenSource();
            cs.CancelAfter(TimeSpan.FromSeconds(0));

            await Assert.ThrowsAsync<TaskCanceledException>(() => _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, RealmName, -1, cs.Token));
        }

        [Fact]
        public async Task GetItemRealmData_CancelTask_Manually()
        {
            var cs = new CancellationTokenSource();

            await Assert.ThrowsAsync<TaskCanceledException>(() =>
            {
                var task = _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, RealmName, -1, cs.Token);
                cs.Cancel();
                return task;
            });
        }

        [Fact]
        public void ChangePrice_Of_Item()
        {
            var data = new TsmItemRealmData();
            data.VendorBuy.Total = 12345;

            Assert.Equal(12345, data.VendorBuy.Total);
            Assert.Equal(1, data.VendorBuy.Gold.Value);
            Assert.Equal(23, data.VendorBuy.Silver.Value);
            Assert.Equal(45, data.VendorBuy.Copper.Value);
        }
    }
}

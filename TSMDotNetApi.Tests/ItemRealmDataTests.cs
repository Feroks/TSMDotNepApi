using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSMDotNetApi.Enums;
using TSMDotNetApi.Exceptions;
using TSMDotNetApi.Tests.Properties;

namespace TSMDotNetApi.Tests
{
    [TestClass]
    public class ItemRealmDataTests
    {
        private static ITsmExplorer _tsmExplorer;
        private static readonly string ApiKey = Resources.ApiKey;
        public static string RealmName { get; } = "Razuvious";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _tsmExplorer = new TsmExplorer(ApiKey);
        }

        [TestMethod]
        public async Task GetItemRealmData_31336()
        {
            var data = await _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, "Twisting Nether", 31336);

            Assert.AreEqual("Blade of Wizardry", data.Name);
            Assert.AreEqual("Weapon", data.Class);
            Assert.AreEqual("Sword", data.SubClass);
            Assert.AreEqual(31336, data.Id);
            Assert.AreEqual(0, data.VendorBuy.Total);
            Assert.AreEqual(432949, data.VendorSell.Total);
            Assert.AreEqual(100, data.Level);
        }

        [TestMethod]
        public async Task GetItemRealmData_Exception()
        {
            await Assert.ThrowsExceptionAsync<TsmFailedException>(() => _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, RealmName, -1));
        }

        [TestMethod]
        public async Task GetItemRealmData_CancelTask_Automatically()
        {
            var cs = new CancellationTokenSource();
            cs.CancelAfter(TimeSpan.FromSeconds(0));

            await Assert.ThrowsExceptionAsync<TaskCanceledException>(() => _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, RealmName, -1, cs.Token));
        }

        [TestMethod]
        public async Task GetItemRealmData_CancelTask_Manually()
        {
            var cs = new CancellationTokenSource();

            await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
            {
                var task = _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, RealmName, -1, cs.Token);
                cs.Cancel();
                return task;
            });
        }
    }
}

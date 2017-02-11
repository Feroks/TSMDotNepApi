using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSMDotNetApi.Enums;
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
            var data = await _tsmExplorer.GetItemRealmDataAsync(TsmRegion.Eu, RealmName, 31336);

            Assert.AreEqual("Blade of Wizardry", data.Name);
            Assert.AreEqual("Weapon", data.Class);
            Assert.AreEqual("Sword", data.SubClass);
            Assert.AreEqual(31336, data.Id);
            Assert.AreEqual(0, data.VendorBuy);
            Assert.AreEqual(432949, data.VendorSell);
            Assert.AreEqual(100, data.Level);
        }
    }
}

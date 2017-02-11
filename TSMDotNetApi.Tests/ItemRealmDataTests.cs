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
        }
    }
}

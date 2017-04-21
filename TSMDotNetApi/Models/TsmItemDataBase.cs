using Newtonsoft.Json;
using TSMDotNetApi.Models.Price;

namespace TSMDotNetApi.Models
{
    public class TsmItemDataBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }

        [JsonProperty("VendorBuy")]
        internal long VendorBuyValue { get; set; }
        [JsonProperty("VendorSell")]
        internal long VendorSellValue { get; set; }

        private TsmPrice _vendorBuy;
        [JsonIgnore]
        public TsmPrice VendorBuy => _vendorBuy ?? (_vendorBuy = new TsmPrice(VendorBuyValue));

        private TsmPrice _vendorSell;
        [JsonIgnore]
        public TsmPrice VendorSell => _vendorSell ?? (_vendorSell = new TsmPrice(VendorSellValue));
    }
}

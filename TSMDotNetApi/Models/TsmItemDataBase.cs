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

        [JsonIgnore]
        public TsmPrice VendorBuy => new TsmPrice(VendorBuyValue);

        [JsonIgnore]
        public TsmPrice VendorSell => new TsmPrice(VendorSellValue);
    }
}

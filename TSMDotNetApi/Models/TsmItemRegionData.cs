using Newtonsoft.Json;
using TSMDotNetApi.Models.Price;

namespace TSMDotNetApi.Models
{
    public class TsmItemRegionData : TsmItemDataBase
    {
        [JsonProperty("RegionMarketAvg")]
        internal long RegionMarketAvgValue { get; set; }

        [JsonProperty("RegionMinBuyoutAvg")]
        internal long RegionMinBuyoutAvgValue { get; set; }

        internal int RegionQuantity { get; set; }

        [JsonProperty("RegionHistoricalPrice")]
        internal long RegionHistoricalPriceValue { get; set; }

        [JsonProperty("RegionSaleAvg")]
        internal long RegionSaleAvgValue { get; set; }

        public float RegionAvgDailySold { get; set; }

        public float RegionSaleRate { get; set; }

        [JsonIgnore]
        public TsmPrice RegionMarketAvg => new TsmPrice(RegionMarketAvgValue);
        [JsonIgnore]
        public TsmPrice RegionMinBuyoutAvg => new TsmPrice(RegionMinBuyoutAvgValue);
        [JsonIgnore]
        public TsmPrice RegionHistoricalPrice => new TsmPrice(RegionHistoricalPriceValue);
        [JsonIgnore]
        public TsmPrice RegionSaleAvg => new TsmPrice(RegionSaleAvgValue);
    }
}

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

        private TsmPrice _regionMarketAvg;
        [JsonIgnore]
        public TsmPrice RegionMarketAvg => _regionMarketAvg ?? (_regionMarketAvg = new TsmPrice(RegionMarketAvgValue));

        private TsmPrice _regionMinBuyoutAvg;
        [JsonIgnore]
        public TsmPrice RegionMinBuyoutAvg => _regionMinBuyoutAvg ?? (_regionMinBuyoutAvg = new TsmPrice(RegionMinBuyoutAvgValue));

        private TsmPrice _regionHistoricalPrice;
        [JsonIgnore]
        public TsmPrice RegionHistoricalPrice => _regionHistoricalPrice ?? (_regionHistoricalPrice = new TsmPrice(RegionHistoricalPriceValue));

        private TsmPrice _regionSaleAvg;
        [JsonIgnore]
        public TsmPrice RegionSaleAvg => _regionSaleAvg ?? (_regionSaleAvg = new TsmPrice(RegionSaleAvgValue));
    }
}

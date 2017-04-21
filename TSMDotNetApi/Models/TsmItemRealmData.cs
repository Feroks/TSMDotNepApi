using Newtonsoft.Json;
using TSMDotNetApi.Models.Price;

namespace TSMDotNetApi.Models
{
    public class TsmItemRealmData : TsmItemDataBase
    {
        [JsonProperty("MarketValue")]
        internal long MarketValueValue { get; set; }
        [JsonProperty("MinBuyout")]
        internal long MinBuyoutValue { get; set; }

        public int Quantity { get; set; }
        public int NumAuctions { get; set; }

        [JsonProperty("HistoricalPrice")]
        internal long HistoricalPriceValue { get; set; }

        [JsonProperty("RegionMarketAvg")]
        internal long RegionMarketAvgValue { get; set; }

        [JsonProperty("RegionMinBuyoutAvg")]
        internal long RegionMinBuyoutAvgValue { get; set; }
        public int RegionQuantity { get; set; }

        [JsonProperty("RegionHistoricalPrice")]
        internal long RegionHistoricalPriceValue { get; set; }

        [JsonProperty("RegionSaleAvg")]
        internal long RegionSaleAvgValue { get; set; }
        public float RegionAvgDailySold { get; set; }
        public float RegionSaleRate { get; set; }

        private TsmPrice _marketValue;
        [JsonIgnore]
        public TsmPrice MarketValue => _marketValue ?? (_marketValue = new TsmPrice(MarketValueValue));

        private TsmPrice _minBuyout;
        [JsonIgnore]
        public TsmPrice MinBuyout => _minBuyout ?? (_minBuyout = new TsmPrice(MinBuyoutValue));

        private TsmPrice _historicalPrice;
        [JsonIgnore]
        public TsmPrice HistoricalPrice => _historicalPrice ?? (_historicalPrice = new TsmPrice(HistoricalPriceValue));

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

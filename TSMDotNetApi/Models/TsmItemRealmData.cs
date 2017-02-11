using Newtonsoft.Json;
using TSMModels.NotificationModels.Price;

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

        [JsonIgnore]
        public TsmPrice MarketValue => new TsmPrice(MarketValueValue);
        [JsonIgnore]
        public TsmPrice MinBuyout => new TsmPrice(MinBuyoutValue);
        [JsonIgnore]
        public TsmPrice HistoricalPrice => new TsmPrice(HistoricalPriceValue);
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

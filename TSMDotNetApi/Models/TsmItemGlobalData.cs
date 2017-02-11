using Newtonsoft.Json;
using TSMModels.NotificationModels.Price;

namespace TSMDotNetApi.Models
{
    public class TsmItemGlobalData : TsmItemDataBase
    {
        [JsonProperty("ItemId")]
        public new int Id { get; set; }

        [JsonProperty("EuMarketAvg")]
        internal long EuMarketAvgValue { get; set; }

        [JsonProperty("EuMinBuyoutAvg")]
        internal long EuMinBuyoutAvgValue { get; set; }

        public int EuQuantity { get; set; }

        [JsonProperty("EuHistoricalPrice")]
        internal long EuHistoricalPriceValue { get; set; }

        [JsonProperty("EuSaleAvg")]
        internal long EuSaleAvgValue { get; set; }

        public float EuAvgDailySold { get; set; }

        public float EuSaleRate { get; set; }

        [JsonProperty("UsMarketAvg")]
        internal long UsMarketAvgValue { get; set; }

        [JsonProperty("UsMinBuyoutAvg")]
        internal long UsMinBuyoutAvgValue { get; set; }

        public int UsQuantity { get; set; }

        [JsonProperty("UsHistoricalPrice")]
        internal long UsHistoricalPriceValue { get; set; }

        [JsonProperty("UsSaleAvg")]
        internal long UsSaleAvgValue { get; set; }

        public float UsAvgDailySold { get; set; }

        public float UsSaleRate { get; set; }

        [JsonIgnore]
        public TsmPrice EuMarketAvg => new TsmPrice(EuMarketAvgValue);
        [JsonIgnore]
        public TsmPrice EuMinBuyout => new TsmPrice(EuMinBuyoutAvgValue);
        [JsonIgnore]
        public TsmPrice EuHistoricalPrice => new TsmPrice(EuHistoricalPriceValue);
        [JsonIgnore]
        public TsmPrice EuSaleAvg => new TsmPrice(EuSaleAvgValue);

        [JsonIgnore]
        public TsmPrice UsMarketAvg => new TsmPrice(UsMarketAvgValue);
        [JsonIgnore]
        public TsmPrice UsMinBuyoutAvg => new TsmPrice(UsMinBuyoutAvgValue);
        [JsonIgnore]
        public TsmPrice UsHistoricalPrice => new TsmPrice(UsHistoricalPriceValue);
        [JsonIgnore]
        public TsmPrice UsSaleAvg => new TsmPrice(UsSaleAvgValue);
    }
}

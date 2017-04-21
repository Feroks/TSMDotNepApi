using Newtonsoft.Json;
using TSMDotNetApi.Models.Price;

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

        private TsmPrice _euMarketAvg;
        [JsonIgnore]
        public TsmPrice EuMarketAvg => _euMarketAvg ?? (_euMarketAvg = new TsmPrice(EuMarketAvgValue));

        private TsmPrice _euMinBuyout;
        [JsonIgnore]
        public TsmPrice EuMinBuyout => _euMinBuyout ?? (_euMinBuyout = new TsmPrice(EuMinBuyoutAvgValue));

        private TsmPrice _euHistoricalPrice;
        [JsonIgnore]
        public TsmPrice EuHistoricalPrice => _euHistoricalPrice ?? (_euHistoricalPrice = new TsmPrice(EuHistoricalPriceValue));

        private TsmPrice _euSaleAvg;
        [JsonIgnore]
        public TsmPrice EuSaleAvg => _euSaleAvg ?? (_euSaleAvg = new TsmPrice(EuSaleAvgValue));

        private TsmPrice _usMarketAvg;
        [JsonIgnore]
        public TsmPrice UsMarketAvg => _usMarketAvg ?? (_usMarketAvg = new TsmPrice(UsMarketAvgValue));

        private TsmPrice _usMinBuyoutAvg;
        [JsonIgnore]
        public TsmPrice UsMinBuyoutAvg => _usMinBuyoutAvg ?? (_usMinBuyoutAvg = new TsmPrice(UsMinBuyoutAvgValue));

        private TsmPrice _usHistoricalPrice;
        [JsonIgnore]
        public TsmPrice UsHistoricalPrice => _usHistoricalPrice ?? (_usHistoricalPrice = new TsmPrice(UsHistoricalPriceValue));

        private TsmPrice _usSaleAvg;
        [JsonIgnore]
        public TsmPrice UsSaleAvg => _usSaleAvg ?? (_usSaleAvg = new TsmPrice(UsSaleAvgValue));
    }
}

namespace TSMDotNetApi.Models
{
    public class TsmItemGlobalData : TsmItemDataBase
    {
        public int EuMarketAvg { get; set; }
        public int EuMinBuyoutAvg { get; set; }
        public int EuQuantity { get; set; }
        public int EuHistoricalPrice { get; set; }
        public int EuSaleAvg { get; set; }
        public float EuAvgDailySold { get; set; }
        public float EuSaleRate { get; set; }
        public int UsMarketAvg { get; set; }
        public int UsMinBuyoutAvg { get; set; }
        public int UsQuantity { get; set; }
        public int UsHistoricalPrice { get; set; }
        public int UsSaleAvg { get; set; }
        public float UsAvgDailySold { get; set; }
        public float UsSaleRate { get; set; }
    }
}

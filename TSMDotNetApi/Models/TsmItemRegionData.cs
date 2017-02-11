namespace TSMDotNetApi.Models
{
    public class TsmItemRegionData : TsmItemDataBase
    {
        public int RegionMarketAvg { get; set; }
        public int RegionMinBuyoutAvg { get; set; }
        public int RegionQuantity { get; set; }
        public int RegionHistoricalPrice { get; set; }
        public int RegionSaleAvg { get; set; }
        public float RegionAvgDailySold { get; set; }
        public float RegionSaleRate { get; set; }
    }
}

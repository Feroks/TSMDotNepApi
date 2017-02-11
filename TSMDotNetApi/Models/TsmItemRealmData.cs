namespace TSMDotNetApi.Models
{
    public class TsmItemRealmData : TsmItemDataBase
    {
        public int MarketValue { get; set; }
        public int MinBuyout { get; set; }
        public int Quantity { get; set; }
        public int NumAuctions { get; set; }
        public int HistoricalPrice { get; set; }
        public int RegionMarketAvg { get; set; }
        public int RegionMinBuyoutAvg { get; set; }
        public int RegionQuantity { get; set; }
        public int RegionHistoricalPrice { get; set; }
        public int RegionSaleAvg { get; set; }
        public int RegionAvgDailySold { get; set; }
        public int RegionSaleRate { get; set; }
    }
}

namespace TSMDotNetApi.Models
{
    public class TsmItemDataBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }
        public int VendorBuy { get; set; }
        public int VendorSell { get; set; }
    }
}

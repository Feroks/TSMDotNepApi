using TSMDotNetApi.Enums;

namespace TSMDotNetApi.Models.Price
{
    public abstract class TsmPriceComponentBase
    {
        protected TsmPriceComponentBase(long value, TsmPriceComponentType type)
        {
            Value = value;
            Type = type;
        }

        public long Value { get; set; }
        public TsmPriceComponentType Type { get; set; }
        public abstract char PriceTextSymbol { get; }
        public virtual string ValueString => Value.ToString();

        public string PriceTextStringified => $"{ValueString}{PriceTextSymbol}";

        public abstract long ToCopper { get; }
    }
}

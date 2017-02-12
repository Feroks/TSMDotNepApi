using TSMDotNetApi.Enums;

namespace TSMDotNetApi.Models.Price
{
    public class TsmPriceComponentSilver : TsmPriceComponentBase
    {
        public TsmPriceComponentSilver(long value) : base(value, TsmPriceComponentType.Silver)
        {
        }

        public override char PriceTextSymbol => 's';
        public override string ValueString => Value.ToString().Length == 1 ? "0" + Value : Value.ToString();
        public override long ToCopper => TsmPriceComponentCopper.FromSilver(this).Value;

        internal static TsmPriceComponentSilver FromGold(TsmPriceComponentGold gold)
        {
            return new TsmPriceComponentSilver(gold.Value * 100);
        }
    }
}
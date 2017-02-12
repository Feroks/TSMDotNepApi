using TSMDotNetApi.Enums;
using TSMDotNetApi.Extensions;

namespace TSMDotNetApi.Models.Price
{
    public class TsmPriceComponentGold : TsmPriceComponentBase
    {
        public TsmPriceComponentGold(long value) : base(value, TsmPriceComponentType.Gold)
        {
        }

        public override char PriceTextSymbol => 'g';
        public override string ValueString => Value.ToString().ReverseString().InsertSymbolAfterNsymbols(3, " ").ReverseString();

        public override long ToCopper => TsmPriceComponentCopper.FromSilver(TsmPriceComponentSilver.FromGold(this)).Value;
    }
}

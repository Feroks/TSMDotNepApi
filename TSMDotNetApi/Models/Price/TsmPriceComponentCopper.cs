using TSMDotNetApi.Enums;
using TSMDotNetApi.Models.Price;

namespace TSMModels.NotificationModels.Price
{
    public class TsmPriceComponentCopper : TsmPriceComponentBase
    {
        public TsmPriceComponentCopper(long value) : base(value, TsmPriceComponentType.Copper)
        {
        }

        public override char PriceTextSymbol => 'c';
        public override string ValueString => Value.ToString().Length == 1 ? "0" + Value : Value.ToString();
        public override long ToCopper => Value;

        internal static TsmPriceComponentCopper FromSilver(TsmPriceComponentSilver silver)
        {
            return new TsmPriceComponentCopper(silver.Value * 100);
        }
    }
}
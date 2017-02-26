using System.Linq;
using TSMDotNetApi.Extensions;

namespace TSMDotNetApi.Models.Price
{
    public class TsmPrice
    {
        internal TsmPrice()
        {
        }

        public TsmPrice(long? totalPrice)
        {
            totalPrice = totalPrice ?? 0;
            Total = (long)totalPrice;
        }

        public TsmPriceComponentGold Gold { get; set; }
        public TsmPriceComponentSilver Silver { get; set; }
        public TsmPriceComponentCopper Copper { get; set; }

        public long Total
        {
            get
            {
                return (Gold?.ToCopper ?? 0) + (Silver?.ToCopper ?? 0) + (Copper?.ToCopper ?? 0);
            }
            private set
            {
                var reverseChars = value.ToString().ToCharArray().Reverse().ToArray().ToList();
                var symbolCount = reverseChars.Count;

                var copperCharCount = symbolCount < 2 ? symbolCount : 2;
                Copper = new TsmPriceComponentCopper(string.Join(string.Empty, reverseChars.Take(copperCharCount).Reverse()).StringToInt());

                var silverCharCount = symbolCount < 4 ? 4 - symbolCount : 2;
                Silver = new TsmPriceComponentSilver(string.Join(string.Empty, reverseChars.Skip(2).Take(silverCharCount).Reverse()).StringToInt());

                if (reverseChars.Count < 5)
                {
                    Gold = new TsmPriceComponentGold(0);
                    return;
                }

                reverseChars.RemoveRange(0, 4);
                reverseChars.Reverse();

                Gold = new TsmPriceComponentGold(string.Join(string.Empty, reverseChars).StringToInt());
            }
        }

        public string StringifiedValue => $"{Gold.PriceTextStringified} {Silver.PriceTextStringified} {Copper.PriceTextStringified}".Trim();

        public string StirngifiedValueGoldOnly => Gold.PriceTextStringified;

        /// <summary>
        /// Create Object from Gold
        /// </summary>
        /// <param name="copper">Total copper count, 1g = 10000c</param>
        /// <returns></returns>
        public static TsmPrice FromGold(long copper)
        {
            return new TsmPrice(copper * 10000);
        }
    }
}
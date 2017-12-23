using System.Collections.Generic;
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

        public long Total { get; set; }

        public TsmPriceComponentGold Gold
        {
            get
            {
                var data = PrepareData(Total).ToList();

                if (data.Count < 5)
                    return new TsmPriceComponentGold(0);

                data.RemoveRange(0, 4);
                data.Reverse();

                return new TsmPriceComponentGold(string.Join(string.Empty, data).StringToInt());
            }
        }

        public TsmPriceComponentSilver Silver
        {
            get
            {
                var data = PrepareData(Total).ToList();

                var silverCharCount = data.Count < 4 ? 4 - data.Count : 2;
                return new TsmPriceComponentSilver(string.Join(string.Empty, data.Skip(2).Take(silverCharCount).Reverse()).StringToInt());
            }
        }

        public TsmPriceComponentCopper Copper
        {
            get
            {
                var data = PrepareData(Total).ToList();

                var copperCharCount = data.Count < 2 ? data.Count : 2;
                return new TsmPriceComponentCopper(string.Join(string.Empty, data.Take(copperCharCount).Reverse()).StringToInt());
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

        private static IEnumerable<char> PrepareData(long value)
        {
            var reverseChars = value.ToString().ToCharArray().Reverse().ToArray().ToList();

            return reverseChars;
        }
    }
}
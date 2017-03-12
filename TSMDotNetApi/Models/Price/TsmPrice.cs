using System;
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
                (List<char> reverseChars, int charCount) = PrepareData(Total);

                if (charCount < 5)
                    return new TsmPriceComponentGold(0);

                reverseChars.RemoveRange(0, 4);
                reverseChars.Reverse();

                return new TsmPriceComponentGold(string.Join(string.Empty, reverseChars).StringToInt());
            }
        }

        public TsmPriceComponentSilver Silver
        {
            get
            {
                (List<char> reverseChars, int charCount) = PrepareData(Total);

                var silverCharCount = charCount < 4 ? 4 - charCount : 2;
                return new TsmPriceComponentSilver(string.Join(string.Empty, reverseChars.Skip(2).Take(silverCharCount).Reverse()).StringToInt());
            }
        }

        public TsmPriceComponentCopper Copper
        {
            get
            {
                (List<char> reverseChars, int charCount) = PrepareData(Total);

                var copperCharCount = charCount < 2 ? charCount : 2;
                return new TsmPriceComponentCopper(string.Join(string.Empty, reverseChars.Take(copperCharCount).Reverse()).StringToInt());
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

        private static (List<char> ReverseChars, int CharCount) PrepareData(long value)
        {
            var reverseChars = value.ToString().ToCharArray().Reverse().ToArray().ToList();
            var charCount = reverseChars.Count;

            return new ValueTuple<List<char>, int>(reverseChars, charCount);
        }
    }
}
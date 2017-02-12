using System;
using System.Linq;

namespace TSMDotNetApi.Extensions
{
    internal static class StringExtensions
    {
        internal static string ReverseString(this string source)
        {
            return string.Join(string.Empty, source.Reverse());
        }

        internal static int StringToInt(this string source)
        {
            int output;
            if (source == null) return 0;
            return int.TryParse(source.Replace(",", string.Empty).Trim(), out output) ? output : 0;
        }

        public static string InsertSymbolAfterNsymbols(this string source, int position, string text)
        {
            return string.Join(text, Enumerable.Range(0, (source.Length - 1) / position + 1)
                .Select(i => source.Substring(i * position, Math.Min(source.Length - i * position, position))));
        }

        internal static string NormalizeServerName(this string source)
        {
            return source.Replace("'", string.Empty).Replace(" ", "-").ToLower();
        }
    }
}

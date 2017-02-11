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
    }
}

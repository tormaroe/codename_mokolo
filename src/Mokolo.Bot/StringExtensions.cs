using System;

namespace Marosoft.Mokolo.Bot
{
    public static class StringExtensions
    {
        public static bool Contains(this string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }

    }
}

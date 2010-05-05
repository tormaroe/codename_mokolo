using System;

namespace Marosoft.Mokolo.Bot
{
    public static class StringExtensions
    {
        public static bool Contains(this string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }

        public static bool IsPhoneNumber(this string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            if (word.Length < 8 || word.Length > 15)
                return false;

            foreach (char c in word)
                if (!Char.IsDigit(c))
                    return false;

            return true;
        }
    }
}

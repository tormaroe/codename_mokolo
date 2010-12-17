using System;
using System.IO;

namespace Marosoft.Mokolo.Bot
{
    /// <summary>
    /// In order to not expose my password on github,
    /// I'm wrapping it up here :)
    /// </summary>
    public static class SmtpSecret
    {
        public static string Value
        {
            get
            {
                return File.ReadAllText(@"C:\data\secret");
            }
        }

    }
}

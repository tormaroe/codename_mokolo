using System;

namespace Marosoft.Mokolo.Bot
{
    public class BotSettings
    {
        public static BotSettings Parse(String[] args)
        {
            var settings = new BotSettings();
            foreach (var arg in args)
            {
                if (arg.StartsWith("/server:")) settings.Server = arg.Substring(8);
                else if (arg.StartsWith("/nick:")) settings.Nick = arg.Substring(6);
                else if (arg.StartsWith("/channel:")) settings.Channel = arg.Substring(9);
            }
            return settings;
        }

        public string Server { get; private set; }
        public string Channel { get; private set; }
        public string Nick { get; private set; }
        
        public void Validate()
        {
            Array.ForEach(new[] { Server, Channel, Nick }, prop => 
            {
                if (string.IsNullOrEmpty(prop))
                    throw new ArgumentException(
                        "Missing argument. You have to specify server, nick, and channel.");
            });
        }
    }
}

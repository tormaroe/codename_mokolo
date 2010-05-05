using System;

namespace Marosoft.Mokolo.Bot
{
    public interface BotSettings
    {
        string Server { get; }
        string Channel { get; }
        string Nick { get; }
        string Topic { get; }
        string PublicScriptFolder { get; }
        string PrivateScriptFolder { get; }
    }
}

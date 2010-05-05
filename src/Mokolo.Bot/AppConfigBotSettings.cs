using System;
using System.Configuration;

namespace Marosoft.Mokolo.Bot
{
    public class AppConfigBotSettings : BotSettings
    {
        public string Server
        {
            get
            {
                return ConfigurationManager.AppSettings["server"];
            }
        }
        public string Channel
        {
            get
            {
                return ConfigurationManager.AppSettings["channel"];
            }
        }
        public string Nick
        {
            get
            {
                return ConfigurationManager.AppSettings["nick"];
            }
        }
        public string PublicScriptFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["public_scripts"];
            }
        }
        public string PrivateScriptFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["private_scripts"];
            }
        }
        public string Topic
        {
            get
            {
                return ConfigurationManager.AppSettings["topic"];
            }
        }
    }
}

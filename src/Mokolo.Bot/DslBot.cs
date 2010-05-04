using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sharkbite.Irc;

namespace Marosoft.Mokolo.Bot
{
    public class DslBot : BotBase
    {
        public DslBot(BotSettings settings)
            : base(settings)
        {

        }

        protected override void HandlePrivateMessage(UserInfo user, string message)
        {

        }
        protected override void HandlePublicMessage(UserInfo user, string channel, string message)
        {

        }
    }
}

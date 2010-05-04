using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sharkbite.Irc;
using Rhino.DSL;

namespace Marosoft.Mokolo.Bot
{
    public class DslBot : BotBase
    {
        private readonly DslFactory _dslFactory;

        public DslBot(BotSettings settings)
            : base(settings)
        {
            _dslFactory = new DslFactory();
            _dslFactory.Register<ResponseStrategy>(new ResponseStrategyDslEngine());
        }

        protected override void HandlePrivateMessage(UserInfo user, string message)
        {

        }

        protected override void HandlePublicMessage(UserInfo user, string channel, string message)
        {
            var strategies = _dslFactory.CreateAll<ResponseStrategy>(_settings.PublicScriptFolder);
            foreach (var strategy in strategies)
            {
                strategy.Initialize(message);
                strategy.ExecuteRule();
                if (strategy.WillRespond)
                {
                    Console.WriteLine("Found strategy, will respond: {0}", strategy.Response);
                    Say(channel, strategy.Response);
                    break;
                }
            }
        }
    }
}

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
            // TODO
        }

        protected override void HandlePublicMessage(UserInfo user, string message)
        {
            var strategies = GetStrategiesThatCanRespond(message, user.Nick, _settings.PublicScriptFolder);

            if (strategies.Count > 0)
            {
                var selectedStrategy = GetPrioritizedStrategy(strategies);
                Console.WriteLine("Found strategy, responding: {0}", selectedStrategy.Response);
                Say(selectedStrategy.Response);
            }
        }

        private List<ResponseStrategy> GetStrategiesThatCanRespond(string message, string user, string responderFolder)
        {
            var availableStrategies = _dslFactory.CreateAll<ResponseStrategy>(responderFolder);
            var strategiesThatCanRespond = new List<ResponseStrategy>();
            foreach (var strategy in availableStrategies)
            {
                strategy.Initialize(message, user);
                strategy.ExecuteRule();
                if (strategy.CanRespond)
                    strategiesThatCanRespond.Add(strategy);
            }
            return strategiesThatCanRespond;
        }

        private static ResponseStrategy GetPrioritizedStrategy(List<ResponseStrategy> strategies)
        {
            Console.WriteLine("{0} valid response strategies found.., sorting and selecting", strategies.Count);
            strategies.Sort((x, y) => x.Priority.CompareTo(y.Priority));
            ResponseStrategy selectedStrategy = strategies.First();
            return selectedStrategy;
        }
    }
}

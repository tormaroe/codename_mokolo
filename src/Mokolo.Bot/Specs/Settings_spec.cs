using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Specs
{
    [TestFixture]
    public class Settings_spec
    {
        private BotSettings settings;

        [SetUp]
        public void SetUp()
        {
            settings = BotSettings.Parse(new[] { "/server:127.0.0.1", "/nick:Mokolo", "/channel:#test" });
        }

        [Test]
        public void Server_will_be_parsed_correctly()
        {
            settings.Server.ShouldEqual("127.0.0.1");
        }
        [Test]
        public void Nick_will_be_parsed_correctly()
        {
            settings.Nick.ShouldEqual("Mokolo");
        }
        [Test]
        public void Channel_will_be_parsed_correctly()
        {
            settings.Channel.ShouldEqual("#test");
        }

        [Test]
        public void Will_validate_when_needed_settings_in_place()
        {
            settings.Validate();
        }
        [Test]
        public void Will_NOT_validate_if_a_needed_settings_is_missing()
        {
            settings = BotSettings.Parse(new[] {"/nick:Foo", "/server:127.0.0.1"});
            typeof(ArgumentException).ShouldBeThrownBy(() => settings.Validate());
        }
    }
}

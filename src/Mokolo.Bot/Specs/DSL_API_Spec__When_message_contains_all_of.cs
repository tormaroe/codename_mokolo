using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    [TestFixture]
    public class DSL_API_Spec__When_message_contains_all_of
        : DSL_API_Context
    {
        bool was_called;

        protected override void Given()
        {
            dsl.Initialize("Some random foobar", "Jack");
            was_called = false;
        }

        [Test]
        public void delegate_should_not_be_called_when_only_some_words_match()
        {
            var list = new Boo.Lang.List(new[] { "Some", "smoogle" });
            dsl.Call_when_message_contains_all_of(list, () => was_called = true);
            was_called.ShouldBeFalse();
        }

        [Test]
        public void delegate_should_be_called_when_all_words_match()
        {
            var list = new Boo.Lang.List(new[] { "Some", "FOOBAR" });
            dsl.Call_when_message_contains_all_of(list, () => was_called = true);
            was_called.ShouldBeTrue();
        }
    }
}

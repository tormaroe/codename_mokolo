using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    [TestFixture]
    public class DSL_API_Spec__When_message_contains_one_of
        : DSL_API_Context
    {
        bool was_called;

        protected override void Given()
        {
            dsl.Initialize("Some random foobar", "Jack");
            was_called = false;
        }

        [Test]
        public void delegate_will_not_be_called_if_none_of_the_values_are_contained()
        {
            var list = new Boo.Lang.List(new[] { "google", "smoogle" });
            dsl.Call_when_message_contains_one_of(list, () => was_called = true);
            was_called.ShouldBeFalse();
        }

        [Test]
        public void delegate_will_be_called_if_one_of_the_values_are_contained_even_if_invalid_case()
        {
            var list = new Boo.Lang.List(new[] { "google", "fOO" });
            dsl.Call_when_message_contains_one_of(list, () => was_called = true);
            was_called.ShouldBeTrue();
        }
    }
}

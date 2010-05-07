using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    [TestFixture]
    public class DSL_API_Spec__When_message_contains
        : DSL_API_Context
    {
        bool was_called;

        protected override void Given()
        {
            dsl.Initialize("Some random foobar", "Jack");
            was_called = false;
        }

        [Test]
        public void delegate_will_not_be_called_if_value_is_not_contained()
        {
            dsl.Call_when_message_contains(some_text, () => was_called = true);
            was_called.ShouldBeFalse();
        }

        [Test]
        public void delegate_will_be_called_if_value_is_contained_even_when_not_matching_case()
        {
            dsl.Call_when_message_contains("FOObar", () => was_called = true);
            was_called.ShouldBeTrue();
        }
    }
}
using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    [TestFixture]
    public class DSL_API_Spec__When_message_contains_phone_number
        : DSL_API_Context
    {        
        [Test]
        public void delegate_will_be_called_if_message_contains_8_digit_number()
        {
            Contains_Phonenumber("Message with phone number - 12345678").ShouldBeTrue();
        }

        [Test]
        public void delegate_will_be_called_if_message_contains_15_digit_number()
        {
            Contains_Phonenumber("Message with long phone number - 123456789012345").ShouldBeTrue();
        }

        [Test]
        public void delegate_will_NOT_be_called_if_no_8_digit_number()
        {
            Contains_Phonenumber("Message with too short number - 1234567").ShouldBeFalse();
        }

        [Test]
        public void delegate_will_NOT_be_called_if_too_long_number()
        {
            Contains_Phonenumber("Message with too long number - 1234567890123456").ShouldBeFalse();
        }

        bool was_called;
        Action action;

        protected override void Given()
        {
            was_called = false;
            action = () => was_called = true;
        }

        private bool Contains_Phonenumber(string message)
        {
            dsl.Initialize(message, "Bill");
            dsl.Call_when_message_contains_phone_number(action);
            return was_called;
        }
    }
}

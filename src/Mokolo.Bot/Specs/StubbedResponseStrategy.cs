using System;
using System.IO;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    public class StubbedResponseStrategy : ResponseStrategy
    {
        public override void ExecuteRule()
        {

        }
        public void CallReply(string message)
        {
            base.reply(message);
        }
        public void CallPriority(int value)
        {
            base.priority(value);
        }
        public void Call_when_message_contains(string expected, Action action)
        {
            base.when_message_contains(expected, action);
        }
        public void Call_when_message_contains_one_of(Boo.Lang.List list, Action action)
        {
            base.when_message_contains_one_of(list, action);
        }
        public void Call_when_message_contains_all_of(Boo.Lang.List list, Action action)
        {
            base.when_message_contains_all_of(list, action);
        }
        public void Call_reply_with_one_of(Boo.Lang.List list)
        {
            base.reply_with_one_of(list);
        }
        public void Call_when_message_contains_phone_number(Action action)
        {
            base.when_message_contains_phone_number(action);
        }
    }
}

using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    [TestFixture]
    public class DSL_API_Spec__Reply 
        : DSL_API_Context
    {
        protected override void When()
        {
            dsl.CallReply(some_text);
        }

        [Test]
        public void reply_will_set_Response_property()
        {
            dsl.Response.ShouldEqual(some_text);
        }

        [Test]
        public void reply_will_set_CanRespond_state()
        {
            dsl.CanRespond.ShouldBeTrue();
        }
    }
}

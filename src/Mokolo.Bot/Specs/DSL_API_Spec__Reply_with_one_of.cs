using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    [TestFixture]
    public class DSL_API_Spec__Reply_with_one_of
        : DSL_API_Context
    {
        protected override void When()
        {
            var two_options = new Boo.Lang.List(new[] { "A", "B" });
            dsl.Call_reply_with_one_of(two_options);
        }

        [Test]
        public void Then_Response_property_will_contain_one_of_them()
        {
            (dsl.Response == "A" || dsl.Response == "B").ShouldBeTrue();
        }
    }
}

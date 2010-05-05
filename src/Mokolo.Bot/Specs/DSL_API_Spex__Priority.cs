using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    public class DSL_API_Spex__Priority
            : DSL_API_Context
    {
        protected override void When()
        {
            dsl.CallPriority(12);
        }

        [Test]
        public void priority_method_will_set_property()
        {
            dsl.Priority.ShouldEqual(12);
        }
    }
}

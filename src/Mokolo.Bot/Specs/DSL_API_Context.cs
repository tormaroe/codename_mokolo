using System;
using NUnit.Framework;

namespace Marosoft.Mokolo.Bot.Spec
{
    [TestFixture]
    public abstract class DSL_API_Context
    {
        [SetUp]
        public void SetUp()
        {
            dsl = new StubbedResponseStrategy();
            Given();
            When();
        }

        protected virtual void Given() { }
        protected virtual void When() { }

        protected StubbedResponseStrategy dsl;
        protected const string some_text = "Some text";
    }
}

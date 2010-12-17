using System;
using NUnit.Framework;
using Rhino.DSL;

namespace Marosoft.Mokolo.Bot.Spec
{
    [TestFixture]
    public class CompilationTests
    {
        [Test]
        public void Can_compile_Reply()
        {
            CanCompile("Reply.boo");
        }
        [Test]
        public void Can_compile_Priority()
        {
            CanCompile("Priority.boo");
        }

        [Test]
        public void Can_compile_Reply_with_one_of()
        {
            CanCompile("Reply_with_one_of.boo");
        }
        [Test]
        public void Can_compile_When_message_contains()
        {
            CanCompile("When_message_contains.boo");
        }
        [Test]
        public void Can_compile_When_message_contains_all_of()
        {
            CanCompile("When_message_contains_all_of.boo");
        }
        [Test]
        public void Can_compile_When_message_contains_one_of()
        {
            CanCompile("When_message_contains_one_of.boo");
        }
        [Test]
        public void Can_compile_When_message_contains_phone_number()
        {
            CanCompile("When_message_contains_phone_number.boo");
        }

        private void CanCompile(string script)
        {
            var dslFactory = new DslFactory();
            dslFactory.Register<ResponseStrategy>(new ResponseStrategyDslEngine());
            var strategy = dslFactory.Create<ResponseStrategy>(String.Format(@"Specs\TestDslScripts\{0}", script));
            strategy.ShouldNotBeNull();
        }
    }
}

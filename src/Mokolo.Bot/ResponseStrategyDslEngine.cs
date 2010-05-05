using System;
using Rhino.DSL;
using Boo.Lang.Compiler;

namespace Marosoft.Mokolo.Bot
{
    public class ResponseStrategyDslEngine : DslEngine
    {
        protected override void CustomizeCompiler(
            BooCompiler compiler,
            CompilerPipeline pipeline,
            string[] urls)
        {
            pipeline.Insert(1,
                new ImplicitBaseClassCompilerStep(
                    typeof(ResponseStrategy),
                    "ExecuteRule", 
                    "System.Net.Mail"));
        }
    }
}

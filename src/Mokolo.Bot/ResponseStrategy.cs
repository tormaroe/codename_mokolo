using System;

namespace Marosoft.Mokolo.Bot
{
    public abstract class ResponseStrategy
    {
        protected string message;

        public void Initialize(string message)
        {
            this.message = message;
        }

        public bool WillRespond { get; private set; }
        public string Response { get; private set; }

        public abstract void ExecuteRule();
        
        protected void reply(string message)
        {
            WillRespond = true;
            Response = message;
        }
    }
}

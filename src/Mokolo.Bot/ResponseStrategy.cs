using System;

namespace Marosoft.Mokolo.Bot
{
    public abstract class ResponseStrategy
    {
        #region Internal Mokolo interface
        public void Initialize(string message, string user)
        {
            this.message = message;
            this.user = user;
            Priority = 100; // default priority
        }

        public bool CanRespond { get; private set; }

        private string _response;
        public string Response 
        { 
            get 
            {
                return _response;
            } 
            private set 
            {
                if (_response == null)
                {
                    _response = value;
                }
                else
                {
                    _response += Environment.NewLine + value;
                }
            } 
        }
        public int Priority { get; private set; }

        /// <summary>
        /// Abstract method will be implemented by the DSL scripts
        /// </summary>
        public abstract void ExecuteRule();

        #endregion

        #region DSL definition (normal conventions do not apply)

        /// <summary>
        /// The received message
        /// </summary>
        protected string message;

        /// <summary>
        /// The nick of the user who sent the message
        /// </summary>
        protected string user;

        protected void reply(string message)
        {
            CanRespond = true;
            Response = message;
        }

        protected void priority(int value)
        {
            Priority = value;
        }

        protected void when_message_contains(string expected, Action actionToPerform)
        {
            if (message.Contains(expected, StringComparison.InvariantCultureIgnoreCase))
                actionToPerform.Invoke();
        }

        protected void when_message_contains_one_of(Boo.Lang.List expected, Action actionToPerform)
        {
            foreach (string expression in expected)
            {
                if (message.Contains(expression, StringComparison.InvariantCultureIgnoreCase))
                {
                    actionToPerform.Invoke();
                    return;
                }
            }
        }

        protected void when_message_contains_all_of(Boo.Lang.List expected, Action actionToPerform)
        {
            foreach (string expression in expected)
            {
                if (!message.Contains(expression, StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }
            }
            actionToPerform.Invoke();
        }

        protected void reply_with_one_of(Boo.Lang.List replies)
        {
            var random = new Random();
            var indexToUse = random.Next(replies.Count);
            Console.WriteLine("replies.Count = {0}, using index {1}", replies.Count, indexToUse);
            reply(replies[indexToUse] as string);
        }

        #endregion
    }
}

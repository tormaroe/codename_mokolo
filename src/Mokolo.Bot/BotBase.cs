using System;
using Sharkbite.Irc;
using System.Threading;

namespace Marosoft.Mokolo.Bot
{
    public abstract class BotBase
    {
        protected BotSettings _settings;
        private Connection _connection;
        private const bool DISABLE_CTCP = false;
        private const bool DISABLE_DCC = false;
        
        public BotBase(BotSettings settings)
        {
            _settings = settings;            
        }

        public void Connect()
        {
            Identd.Start(_settings.Nick);
            var connectionArgs = new ConnectionArgs(_settings.Nick, _settings.Server);
            _connection = new Connection(connectionArgs, DISABLE_CTCP, DISABLE_DCC);
            InitializeEvents();
            try
            {
                Console.WriteLine("* Connecting to {0} as {1}", _settings.Server, _settings.Nick);
                _connection.Connect();
            }
            catch
            {
                Identd.Stop();
                throw;
            }
        }

        private void InitializeEvents()
        {
            _connection.Listener.OnRegistered += Listener_OnRegistered;
            
            _connection.Listener.OnPublic += Listener_OnPublic;
            _connection.Listener.OnPrivate += Listener_OnPrivate;

            _connection.Listener.OnJoin += (user, channel) => Console.WriteLine("* {0} joined channel {1}", user.Nick, channel);
            _connection.Listener.OnError += (code, message) => Console.WriteLine("*** An error of type " + code + " due to " + message + " has occurred.");            
            _connection.Listener.OnDisconnected += () => Console.WriteLine("*** Connection to server has been closed"); ;
        }

        void Listener_OnRegistered()
        {
            Console.WriteLine("* Registered");
            Identd.Stop();
            _connection.Sender.Join(_settings.Channel);
        }

        protected void Listener_OnPrivate(UserInfo user, string message)
        {
            HandleMessage("Private", HandlePrivateMessage, user, message);
        }

        private void Listener_OnPublic(UserInfo user, string channel, string message)
        {
            HandleMessage("Public", HandlePublicMessage, user, message);
        }

        protected abstract void HandlePrivateMessage(UserInfo user, string message);
        protected abstract void HandlePublicMessage(UserInfo user, string message);

        private void HandleMessage(string messageType, Action<UserInfo, string> handler, UserInfo user, string message)
        {
            Console.WriteLine("{0} msg from {1} > {2}", messageType, user.Nick, message);
            try
            {
                handler.Invoke(user, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("*** ERROR when handling {0} message:", messageType);
                Console.WriteLine(ex);
            }
        }

        protected void Say(string response)
        {
            var messages = response.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            Array.ForEach(messages, msg => 
            {
                _connection.Sender.PublicMessage(_settings.Channel, msg);
                Thread.Sleep(500);
            });
        }
    }
}

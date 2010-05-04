using System;
using Sharkbite.Irc;

namespace Marosoft.Mokolo.Bot
{
    public abstract class BotBase
    {
        private BotSettings _settings;
        private Connection _connection;
        private const bool DIsABLE_CTCP = false;
        private const bool DISABLE_DCC = false;
        
        public BotBase(BotSettings settings)
        {
            _settings = settings;            
        }

        public void Connect()
        {
            Identd.Start(_settings.Nick);
            var connectionArgs = new ConnectionArgs(_settings.Nick, _settings.Server);
            _connection = new Connection(connectionArgs, DIsABLE_CTCP, DISABLE_DCC);
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
            Console.WriteLine("Private msg from {0} > {1}", user.Nick, message);
            HandlePrivateMessage(user, message);
        }

        protected abstract void HandlePrivateMessage(UserInfo user, string message);

        private void Listener_OnPublic(UserInfo user, string channel, string message)
        {
            Console.WriteLine("Public msg from {0} > {1}", user.Nick, message);
            HandlePublicMessage(user, channel, message);
        }

        protected abstract void HandlePublicMessage(UserInfo user, string channel, string message);

    }
}

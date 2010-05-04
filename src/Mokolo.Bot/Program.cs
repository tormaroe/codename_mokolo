using System;

namespace Marosoft.Mokolo.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new DslBot(BotSettings.Parse(args)).Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("*** ERROR ***");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
            }
        }
    }
}
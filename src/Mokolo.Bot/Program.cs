using System;

namespace Marosoft.Mokolo.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new DslBot(new AppConfigBotSettings()).Connect();
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
using System;

namespace LuccaDevises
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length < 1)
            {
                Console.WriteLine("Invalid argument count");
                Environment.ExitCode = 1;
                return;
            }
            ConfigManager configManager = ConfigManager.GetInstance();
            try
            {
                configManager.LoadAndParseConfig(args[0]);
            }
            catch (Exceptions.LuccaDevisesException e)
            {
                Console.WriteLine(e.Message);
                Environment.ExitCode = 1;
                return;
            }

            CurrencyConverter converter = new CurrencyConverter();

            Console.WriteLine(converter.Convert(configManager.CurrencyFrom, configManager.CurrencyTo, configManager.Value));
        }
    }
}

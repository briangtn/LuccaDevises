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
            int result = converter.Convert(configManager.CurrencyFrom, configManager.CurrencyTo, configManager.Value);
            if (result < 0)
            {
                Console.WriteLine("Impossible to find a path to convert this value");
                Environment.ExitCode = 1;
                return;
            }
            Console.WriteLine(result);
        }
    }
}

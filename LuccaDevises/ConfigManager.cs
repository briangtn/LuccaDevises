using System;
using System.Collections.Generic;

namespace LuccaDevises
{
    public class ConfigManager
    {

        /*
         * Singleton
         */

        private static ConfigManager _instance = null;

        public static ConfigManager GetInstance()
        {
            if (_instance == null)
                _instance = new ConfigManager();
            return _instance;
        }

        /*
         * ConfigParser class
         */

        public string[] ConfigLines { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public double Value { get; set; }
        private Dictionary<string, CurrencyNode> Currencies;

        private ConfigManager()
        {
            Currencies = new Dictionary<string, CurrencyNode>();
        }

        public void LoadAndParseConfig(string configFile)
        {
            LoadConfig(configFile);
            ParseConfig();
        }

        public void LoadConfig(string configFile)
        {
            if (!System.IO.File.Exists(configFile))
            {
                throw new Exceptions.ConfigNotFoundException("Config " + configFile + " not found");
            }

            ConfigLines = System.IO.File.ReadAllLines(configFile);
        }

        public Dictionary<string, CurrencyNode> GetCurrencies()
        {
            return Currencies;
        }

        public void ParseConfig()
        {
            try
            {
                string[] firstLineParts = ConfigLines[0].Split(';');
                CurrencyFrom = firstLineParts[0];
                Value = double.Parse(firstLineParts[1]);
                CurrencyTo = firstLineParts[2];
                int linesCount = Int32.Parse(ConfigLines[1]);

                if (ConfigLines.Length < linesCount + 2)
                {
                    throw new Exceptions.InvalidConfigException("Invalid currencies lines count given.");
                }

                for (int i = 0; i < linesCount; i++)
                {
                    string line = ConfigLines[i + 2];
                    string[] parts = line.Split(';');

                    if (parts.Length < 3)
                    {
                        throw new Exceptions.InvalidConfigException("Configuration invalid at line " + i + 3 + ".");
                    }

                    string currencyFrom = parts[0];
                    string currencyTo = parts[1];
                    double changeValue = double.Parse(parts[2]);

                    CurrencyNode currencyNodeFrom = null;
                    if (!Currencies.ContainsKey(currencyFrom))
                    {
                        currencyNodeFrom = new CurrencyNode(currencyFrom);
                        Currencies.Add(currencyFrom, currencyNodeFrom);
                    }
                    else
                    {
                        currencyNodeFrom = Currencies[currencyFrom];
                    }

                    CurrencyNode currencyNodeTo = null;
                    if (!Currencies.ContainsKey(currencyTo))
                    {
                        currencyNodeTo = new CurrencyNode(currencyTo);
                        Currencies.Add(currencyTo, currencyNodeTo);
                    }
                    else
                    {
                        currencyNodeTo = Currencies[currencyTo];
                    }

                    currencyNodeFrom.AddLinkedCurrency(ref currencyNodeTo, changeValue);
                    currencyNodeTo.AddLinkedCurrency(ref currencyNodeFrom, 1 / changeValue);
                }
            }
            catch (FormatException)
            {
                throw new Exceptions.InvalidConfigException("Invalid configuration, please check your number formats");
            }
        }     
    }
}

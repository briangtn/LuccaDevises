using System;
using System.Collections.Generic;


namespace LuccaDevises
{
    public class CurrencyNode
    {

        public List<KeyValuePair<CurrencyNode, double>> LinkedCurrencies { get; set; }
        public string Name { get; set; }

        public CurrencyNode(string name)
        {
            LinkedCurrencies = new List<KeyValuePair<CurrencyNode, double>>();
            Name = name;
        }

        public void AddLinkedCurrency(ref CurrencyNode node, double convertingRate)
        {
            LinkedCurrencies.Add(new KeyValuePair<CurrencyNode, double>(node, convertingRate));
        }
    }
}

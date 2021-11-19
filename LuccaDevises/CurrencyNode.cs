using System;
using System.Collections.Generic;


namespace LuccaDevises
{
    public class CurrencyNode
    {

        public List<KeyValuePair<CurrencyNode, float>> LinkedCurrencies { get; set; }
        public string Name { get; set; }

        public CurrencyNode(string name)
        {
            LinkedCurrencies = new List<KeyValuePair<CurrencyNode, float>>();
            Name = name;
        }

        public void AddLinkedCurrency(ref CurrencyNode node, float convertingRate)
        {
            LinkedCurrencies.Add(new KeyValuePair<CurrencyNode, float>(node, convertingRate));
        }
    }
}

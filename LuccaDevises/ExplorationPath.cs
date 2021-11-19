using System;
using System.Collections.Generic;

namespace LuccaDevises
{
    public class ExplorationPath
    {

        private Dictionary<string, double> Path;
        public bool IsValidPath { get; set; }

        public ExplorationPath()
        {
            Path = new Dictionary<string, double>();
            IsValidPath = false;
        }

        public void AddToPath(CurrencyNode node, double value)
        {
            Path.Add(node.Name, value);
        }

        public void AddToPath(string nodeName, double value)
        {
            Path.Add(nodeName, value);
        }

        public Dictionary<string, double> GetPath()
        {
            return Path;
        }

        public ExplorationPath Clone()
        {
            ExplorationPath copy = new ExplorationPath();
            copy.Path = new Dictionary<string, double>();
            copy.IsValidPath = IsValidPath;

            foreach(KeyValuePair<string, double> keyValuePair in Path)
            {
                copy.Path.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return copy;
        }
    }
}

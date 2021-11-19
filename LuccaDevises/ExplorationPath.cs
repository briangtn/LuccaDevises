using System;
using System.Collections.Generic;

namespace LuccaDevises
{
    public class ExplorationPath
    {

        private Dictionary<string, float> Path;
        public bool IsValidPath { get; set; }

        public ExplorationPath()
        {
            Path = new Dictionary<string, float>();
            IsValidPath = false;
        }

        public void AddToPath(CurrencyNode node, float value)
        {
            Path.Add(node.Name, value);
        }

        public void AddToPath(string nodeName, float value)
        {
            Path.Add(nodeName, value);
        }

        public Dictionary<string, float> GetPath()
        {
            return Path;
        }

        public ExplorationPath Clone()
        {
            ExplorationPath copy = new ExplorationPath();
            copy.Path = new Dictionary<string, float>();
            copy.IsValidPath = IsValidPath;

            foreach(KeyValuePair<string, float> keyValuePair in Path)
            {
                copy.Path.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return copy;
        }
    }
}

using System;
using System.Collections.Generic;

namespace LuccaDevises
{
    public class CurrencyConverter
    {
        public CurrencyConverter()
        {
        }

        public List<string> ExploredNodes = new List<string>();

        public int Convert(string from, string to, float value)
        {
            if (from == to)
            {
                return (int) value;
            }
            ExploredNodes = new List<string>();

            List<ExplorationPath> explorations = ExplorePath(new ExplorationPath(), ConfigManager.GetInstance().GetCurrencies()[from], to);
            ExplorationPath shortestPath = FindShortestValidPath(explorations);

            if (shortestPath == null)
            {
                return -1;
            }

            return (int) ConvertFromPath(shortestPath.GetPath(), value);
        }

        private ExplorationPath FindShortestValidPath(List<ExplorationPath> explorations)
        {
            int shortestPathSize = ConfigManager.GetInstance().GetCurrencies().Count;
            ExplorationPath shortestPath = null;

            foreach(ExplorationPath exploration in explorations)
            {
                if (exploration.GetPath().Count <= shortestPathSize && exploration.IsValidPath)
                {
                    shortestPath = exploration;
                    shortestPathSize = exploration.GetPath().Count;
                }
            }
            return shortestPath;
        }

        private float ConvertFromPath(Dictionary<string, float> path, float value)
        {
            foreach(KeyValuePair<string, float> pathElement in path)
            {
                value *= pathElement.Value;
            }
            return value;
        }

        private List<ExplorationPath> ExplorePath(
                ExplorationPath exploration,
                CurrencyNode currentNode,
                string searchedCurrency
            )
        {
            List<ExplorationPath> explorations = new List<ExplorationPath>();

            ExploredNodes.Add(currentNode.Name);

            foreach (KeyValuePair<CurrencyNode, float> keyValue in currentNode.LinkedCurrencies)
            {
                ExplorationPath newExploration = exploration.Clone();

                if (keyValue.Key.Name == searchedCurrency)
                {
                    ExploredNodes.Add(currentNode.Name);
                    newExploration.IsValidPath = true;
                    newExploration.AddToPath(keyValue.Key.Name, keyValue.Value);
                    explorations.Add(newExploration);
                    continue;
                }
                if (ExploredNodes.Contains(keyValue.Key.Name))
                    continue;

                newExploration.AddToPath(keyValue.Key.Name, keyValue.Value);
                explorations.AddRange(ExplorePath(newExploration, keyValue.Key, searchedCurrency));
                explorations.Add(newExploration);
            }
            return explorations;
        }

        private void DisplayExploration(ExplorationPath exploration)
        {
            Console.WriteLine("");
            Console.WriteLine("=============================");
            Console.WriteLine("Exploring... " + exploration.IsValidPath);
            foreach (KeyValuePair<string, float> path in exploration.GetPath())
            {
                Console.WriteLine("-> " + path.Key + " : " + path.Value);
            }
            Console.WriteLine("=============================");
            Console.WriteLine("");
        }


        private void DisplayExplorations(List<ExplorationPath> explorations)
        {
            foreach (ExplorationPath exploration in explorations)
            {
                DisplayExploration(exploration);
            }
        }
    }
}

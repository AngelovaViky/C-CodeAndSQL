using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] item = command.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string nameShop = item[0];
                string product = item[1];
                double price = double.Parse(item[2]);

                if (!shops.ContainsKey(nameShop))
                {
                    shops.Add(nameShop, new Dictionary<string, double>());
                    shops[nameShop].Add(product, price);
                }
                else
                {
                    shops[nameShop].Add(product, price);
                }
                command = Console.ReadLine();
            }
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}

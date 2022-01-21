using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var earth = new Dictionary<string, Dictionary<string, List<string>>>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] item = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string continents = item[0];
                string countries = item[1];
                string cities = item[2];
                if (!earth.ContainsKey(continents))
                {
                    earth.Add(continents, new Dictionary<string, List<string>>());
                }

                if (!earth[continents].ContainsKey(countries))
                {
                    earth[continents].Add(countries, new List<string>());
                }

                earth[continents][countries].Add(cities);
            }
            foreach (var name in earth)
            {
                Console.WriteLine($"{name.Key}:");
                foreach (var city in name.Value)
                {
                    Console.WriteLine($"   {city.Key} -> {string.Join(", ", city.Value)}");
                }
            }
        }
    }
}

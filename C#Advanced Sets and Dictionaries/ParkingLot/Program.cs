using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] split = command.Split(", ");
                if (split[0] == "IN")
                {
                    cars.Add(split[1]);
                }
                else if (split[0] == "OUT")
                {
                    if (!cars.Contains(split[1]))
                    {
                        continue;
                    }
                    else
                    {
                        cars.Remove(split[1]);
                    }
                }
                command = Console.ReadLine();
            }

            if (cars.Count <= 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string reservation = Console.ReadLine();
            string regex = @"[0-9][A-Za-z0-9]{7}";
            Regex checkVip = new Regex(regex);
            while (reservation != "PARTY")
            {
                if (checkVip.IsMatch(reservation))
                {
                    vip.Add(reservation);
                }
                else
                {
                    regular.Add(reservation);
                }
                reservation = Console.ReadLine();
            }
            string reservation1 = Console.ReadLine();
            while (reservation1 != "END")
            {
                if (vip.Contains(reservation1))
                {
                    vip.Remove(reservation1);
                }
                else if (regular.Contains(reservation1))
                {
                    regular.Remove(reservation1);
                }
                reservation1 = Console.ReadLine();
            }
            Console.WriteLine(vip.Count + regular.Count);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}

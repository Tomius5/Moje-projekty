using System;
using System.Collections.Generic;
using System.Linq;

namespace Mince
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Console.WriteLine("Zadej mince:");

            // List<int> mince = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> mince = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.WriteLine("Zadej částku:");
            int cil = int.Parse(Console.ReadLine());
            List<List<int>> vysledky = new List<List<int>>();



            Rekurze(cil, mince, new List<int>(), 0, vysledky);



            if (vysledky.Count == 0)
            {
                Console.WriteLine("Žádné řešení");
            }
            else
            {

                foreach (var v in vysledky)
                {
                    Console.WriteLine(string.Join(" ", v));
                }
            }

            Console.ReadLine();
        }



        static void Rekurze(int cil, List<int> mince, List<int> current, int od, List<List<int>> vysledky)
        {


            //int soucet = 0;
            //foreach(var x in current)
            //{
            //    soucet += x;
            //}


            int soucet = current.Sum();

            if (soucet == cil)
            {
                vysledky.Add(new List<int>(current));
                return;
            }



            for (int i = od; i < mince.Count; i++)
            {
                if (soucet + mince[i] <= cil)
                {
                    current.Add(mince[i]);
                    Rekurze(cil, mince, current, i, vysledky);
                    current.RemoveAt(current.Count - 1);
                }


                // Console.WriteLine(mince[i]);
            }
        }



    }
}
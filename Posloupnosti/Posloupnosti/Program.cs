using System;
using System.Collections.Generic;
using System.Linq;

namespace Posloupnosti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej posloupnost:");
            List<int> x = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = x.Count;
            // x.Add(int.MinValue);
            x.Insert(0, int.MinValue);
            int[] T = new int[n + 1];
            int[] P = new int[n + 1];



            for (int i = n; i >= 0; i--)
            {
                T[i] = 1;
                P[i] = 0;

                for (int j = i + 1; j <= n; j++)
                {
                    if (x[i] < x[j] && T[i] < 1 + T[j])
                    {
                        T[i] = 1 + T[j];
                        P[i] = j;
                    }

                }


            }
            // Console.WriteLine(T[0]);
            Console.WriteLine("Délka nejdelší posloupnosti: " + (T[0] - 1));
            List<int> vysledek = new List<int>();
            int k = P[0];
            while (k != 0)
            {
                vysledek.Add(x[k]);

                k = P[k];
            }
            Console.WriteLine("Podposloupnost:");
            // Console.WriteLine(vysledek);
            Console.WriteLine(string.Join(" ", vysledek));
            Console.ReadLine();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._9._Projekt_final_final
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sup nigga, vítej v tomto projektu!");
            Console.WriteLine("Chceš přidat hodnocení ano/ne?");
            string opinion = Console.ReadLine();
        }
    }
    class Film
    {
        string Nazev;
        string JmenoRezisera;
        string PrijmeniRezisera;
        int RokVzniku;
        List<double> HodnoceniCelkem;
        public double Hodnoceni { get; private set; }
        public void HodnoceniPridat(double NoveHodnoceni)
        {
            HodnoceniCelkem.Add(NoveHodnoceni);
            double sum = HodnoceniCelkem.Sum();
            int count = HodnoceniCelkem.Count();
            Hodnoceni = sum / count;
        }
    }

}

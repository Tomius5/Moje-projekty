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
            Film film1 = new Film("Princezna nevěsta", "Víťa", "Jahoda", 1939);
            Film film2 = new Film("Nevěsta princezna", "Víťa", "Jahoda", 1945);
            Film film3 = new Film("Princezna a zároveň nevěsta", "Víťa", "Jahoda", 2025);
            Console.WriteLine("Sup nigga, vítej v tomto projektu!");
            // Console.WriteLine("Chceš přidat hodnocení ano/ne?");
            // string opinion = Console.ReadLine();
            film1.HodnoceniPridat(3.5);
            film1.HodnoceniPridat(1.5);
            film1.HodnoceniPridat(4.3);
            List<Film> list = new List<Film>();
            list.Add(film1);
            list.Add(film2);
            list.Add(film3);
            int hodnoceni;
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                hodnoceni = rnd.Next(0, 5);
                film1.HodnoceniPridat(hodnoceni);
            }
            film1.FilmVypsatInfo();
            film1.HodnoceniFilmuVypsat(); //
            film2.FilmVypsatInfo();
            film3.FilmVypsatInfo();
            Console.ReadLine();
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

        public Film(string nazev, string jmeno, string prijmeni, int rok)
        {
            Nazev = nazev;
            JmenoRezisera = jmeno;
            PrijmeniRezisera = prijmeni;
            RokVzniku = rok;
            HodnoceniCelkem = new List<double>();
        }

        public void HodnoceniPridat(double NoveHodnoceni)
        {
            HodnoceniCelkem.Add(NoveHodnoceni);
            double sum = HodnoceniCelkem.Sum();
            int count = HodnoceniCelkem.Count;
            Hodnoceni = sum / count;
        }

        public void HodnoceniFilmuVypsat()
        {
            for (int i = 0; i < HodnoceniCelkem.Count; i++)
            {
                Console.WriteLine(HodnoceniCelkem[i]);
            }
        }
        public void FilmVypsatInfo()
        {
            string RokVzinkuSTR = RokVzniku.ToString() + " ";
            string NazevSTR = Nazev.ToString() + " ";
            string PrijmeniSTR = PrijmeniRezisera.ToString() + " ";
            string JmenoSTR = JmenoRezisera[0].ToString() + ".";
            string HodnoceniSTR = Hodnoceni.ToString() + "⭐/5⭐";
            if(Hodnoceni < 3)
            {
                Console.WriteLine(NazevSTR + "je odpad, má moc špatné hodnocení!");
            }
            Console.WriteLine(NazevSTR + "(" + RokVzinkuSTR + PrijmeniSTR + JmenoSTR + "): " + HodnoceniSTR);
        }
    }
}

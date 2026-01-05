namespace StabilniManzelstvi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej, prosím, vstup:");

            int n;

            // int n = int.Parse(Console.ReadLine());
            // padalo to, když tam byl blbej vstup, tak jsem to radši přepsal

            bool ok = int.TryParse(Console.ReadLine(), out n);

            Zena[] holky = new Zena[n];
            Muz[] kluci = new Muz[n];

            // List<Zena> holky = new List<Zena>();
            // List<Muz> kluci = new List<Muz>();


            for (int i = 0; i < n * 2; i++)
            {
                string radek = Console.ReadLine();


                // string[] casti = radek.Split(' ');
                // int[] cisla = new int[n];
                // for (int j = 0; j < casti.Length; j++)
                //     cisla[j] = int.Parse(casti[j]);


                int[] cisla = radek.Split(' ')
                                   .Select(x => int.Parse(x))
                                   .ToArray();
                //Console.WriteLine(radek);
                if (i < n)
                {
                    holky[i] = new Zena(i + 1, cisla);

                    // holky.Add(new Zena(i, cisla));

                }
                else
                {
                    kluci[i - n] = new Muz(i - n + 1, cisla);

                    //
                    // kluci.Add(new Muz(i, cisla));

                }
            }

            Manzelstvi neco = new Manzelstvi(kluci, holky);

            // for (int i = 0; i < n; i++)
            //     neco.UdelejJednoKolo();
            // tohle nedávalo správný výsledek, muselo se jet dokud je někdo volnej

            while (neco.Free())
            {
                neco.Kolo();
            }

            Console.WriteLine("vystup:");

            foreach (Zena z in holky)
            {
                Console.WriteLine(z.ManzelId);

                // Console.WriteLine(z.Id + " -> " + z.ManzelId);
                // učitel chtěl jen id manžela, tak jsem to zjednodušil
            }
        }


        class Manzelstvi
        {
            public Muz[] Kluci;
            public Zena[] Holky;

            public Manzelstvi(Muz[] k, Zena[] h)
            {
                Kluci = k;
                Holky = h;
            }

            public void Kolo()
            {
                foreach (Zena z in Holky)
                {
                    if (z.ManzelId == null)
                    {
                        int koho = z.Queue.Dequeue();

                        Kluci[koho - 1].DosleNavrhy.Add(z.Id);
                    }

                }

                foreach (Muz m in Kluci)
                {
                    int? vyherce = m.ManzelId; // nemusí
                    int bestScore = vyherce == null ? 999999 : m.PreferencePoradi[(int)vyherce];

                    foreach (int navrh in m.DosleNavrhy)
                    {
                        if (m.PreferencePoradi[navrh] < bestScore)
                        {
                            vyherce = navrh;
                            bestScore = m.PreferencePoradi[navrh];
                        }
                    }

                    if (vyherce == null)

                        continue;

                    if (vyherce != m.ManzelId)
                    {
                        if (m.ManzelId != null)
                        {
                            Holky[(int)m.ManzelId - 1].ManzelId = null;

                        }

                        m.ManzelId = vyherce;
                        Holky[(int)vyherce - 1].ManzelId = m.Id;
                    }
                    //else
                    m.DosleNavrhy.Clear();
                }
            }

            public bool Free()
            {
                foreach (Zena z in Holky)
                {
                    if (z.ManzelId == null)
                        return true;
                }
                return false;
            }
        }

        abstract class OsobaBase
        {
            public int Id;
            public int? ManzelId; //nemusí bejt

            public OsobaBase(int id)
            {
                Id = id;
                ManzelId = null;
            }
        }
        class Zena : OsobaBase
        {
            public Queue<int> Queue;


            public Zena(int id, IEnumerable<int> pref) : base(id)
            {
                Queue = new Queue<int>(pref);
            }
        }
        class Muz : OsobaBase
        {
            public Dictionary<int, int> PreferencePoradi;
            public List<int> DosleNavrhy;

            public Muz(int id, int[] pref) : base(id)
            {
                PreferencePoradi = new Dictionary<int, int>();
                for (int i = 0; i < pref.Length; i++)
                {

                    PreferencePoradi[pref[i]] = i;
                }
                DosleNavrhy = new List<int>();
            }
        }
        //   class Zena : OsobaBase
        // {
        //       public int[] Preference;   
        //
        //     public Zena(int id, int[] pref) : base(id)
        //      {
        //         Preference = pref;
        //     }
        //
        //     public int Next()
        //     {
        //         return Preference[0]; 
        //     }
        // }
    }
}

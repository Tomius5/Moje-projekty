using System;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;
namespace _14._12._práce_se_soubory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*/ // <-- stačí když jednu ze dvou * smažete a celá
            studijní část se zakomentuje (a naopak)
            #region Studijní část
            // 1. OTEVŘENÍ SOUBORU
            // 1.1 Adresa k souboru (File PATH):
            //  - RELATIVNÍ vzhledem k EXE souboru (ve složce ...\Váš
            //    projekt\bin\Debug\netX.Y\)
            //      - př. "vstupni_soubor.txt"
            //      - př. @"vstupy\1.txt" -> použijeme zavináč,
            //        abychom nemuseli zdvojovat zpětná lomítka (vedou obvykle na vyjádření
            //        speciálních znaků)
            //      - př. @"..\vstupy\1.txt" -> jdeme o složku zpět a
            //        v ní hledáme složku "vstupy" se souborem 1.txt
            //  - ABSOLUTNÍ adresa:
            //      - př. @"C:\\Users\\mysak\\Documents\\03_TEACHING\\02_SEMINAR_Z_PROGRAMOVANI\\25_26\\PrgSem2\\vstup.txt"

            // 1.2 Blok using
            //  - soubor otevíráme vždy v rámci bloku "using", který
            //    zajišťuje uzavření souboru a to vždy (i kdyby program v průběhu spadl)
            //  - syntaktická zkratka za try - finally blok (bez
            //    catch!) - ve finally se uzavírá soubor a odemyká se pro další
            //    používání

            // 2. ČTENÍ ZE SOUBORU
            // 2.1 File
            //  - vhodný pro menší až střední soubory, které můžeme
            //    přečíst celé najednou (vejdou se celé do paměti)
            //  - neumí číst po částech
            //  - nemusí být v using bloku (uzavření si hlídá sám)
            string text = File.ReadAllText("data.txt");
            string[] lines = File.ReadAllLines("data.txt");

            // 2.2 StreamReader
            //  - při volání konstruktoru specifikujeme adresu k souboru
            //  - vhodný pro větší soubory a čtení/zápis po částech

            using (StreamReader sr = new StreamReader(@"vstupy\0_vstup.txt"))
            {
                //  - nabízí funkce pro čtení souboru (pokračuje od
                //    místa, kde se skončilo číst):
                char prvniZnak = (char)sr.Read(); // přečteme 1 znak,
                // vrací int (-1, když konec souboru)
                string zbytekPrvniRadky = sr.ReadLine(); // od prvního
                // znaku dočte zbytek až do oddělovače řádku
                string zbytekSouboru = sr.ReadToEnd(); // přečte
                // zbytek souboru od místa, kde se skončilo se čtením
            }

            // 3. ZÁPIS DO SOUBORU
            // 3.1 File
            //  - rozlišujeme mezi WRITE (přepsání) a APPEND (připsání)
            File.WriteAllText("vystup.txt", "Ahoj světe!\nToto je nový soubor."); // \n - oddělovač řádků
            File.AppendAllText("vystup.txt", "Přidáváme další řádku.\n");
            string[] radky = { "První řádek", "Druhý řádek", "Třetí řádek" };
            File.WriteAllLines("vystup.txt", radky); // PŘEPÍŠE několik řádků souborů
            string[] dalsiRadky = { "Čtvrtý řádek", "Pátý řádek" };
            File.AppendAllLines("vystup.txt", dalsiRadky);

            // 3.2 StreamWriter
            using (StreamWriter sw = new StreamWriter("vystup.txt", false)) // false -> PŘEPISOVÁNÍ, true -> PŘIPISOVÁNÍ (append)
            {
                // Upozornění: pokud soubor s takovým jménem
                // neexistoval, vytvoří ho

                sw.Write("Ahoj"); // píše se tam, kde se skončilo
                sw.WriteLine("Toto je nová řádka"); // přidá se oddělení řádku
            }

            // 4. PROBLÉMY
            //  - při práci se soubory může dojít k různým výjimkám ->
            //    používáme try-catch bloky
            try
            {
                using (StreamReader sr = new StreamReader(@"vstupy\0_vstup.txt"))
                {
                    // čtení
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Soubor nebyl nalezen: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Nemáme práva k souboru nebo složce.
                // Např. zápis do chráněného systému (C:\\Windows...)
                // nebo čtení souboru, který je uzamčen pro čtení.
                Console.WriteLine("Nemáš oprávnění: " + ex.Message);
            }
            catch (IOException ex)
            {
                // obecná I/O (input/output) chyba (např. soubor je
                // uzamčen jiným procesem)
                Console.WriteLine("Chyba vstupu/výstupu: " + ex.Message);
            }
            catch
            {
                Console.WriteLine("Nastala nějaká chyba");
            }
            #endregion
            /**/

            #region Praktická část
            // Následující úkoly vyřešte pomocí programování. Metodu
            // "kouknu a vidim" si nechte pro kontrolu.
            // Výsledek si nechte vypsat do konzole a uveďte odpověď v
            // komentáři.
            // Vyřešte vždy i všechny podotázky.

            // Složku vstupni_soubory si přesuňte do ...\bin\Debug\netX.Y\.
            // Dále si ji otevřte ve VS Code a sledujte obsah souborů.
            // Doporučení: pro důkladnější pátrání si stáhněte
            // extension do VS Code Inspector Hex nebo Hex Editor.

            // using (StreamWriter sw = new StreamWriter(@"..\..\..\..\vstupni_soubory\2.txt"))
            // {
            //     sw.WriteLine("Ahoj \tsvěte!\n");
            // }

            // (10b) 1. Jaký je počet znaků v souboru 1.txt a jaký v 2.txt?
            // Zkontrolujte s VS Code a vysvětlete rozdíly.
            // Tip: Při Debugování uvidíte všechny čtené znaky.

            using (FileStream fs = System.IO.File.Open("1.txt", FileMode.Open))
            {
                long length = new FileInfo("1.txt").Length;
                Console.WriteLine(length);
            }

            using (FileStream fs = System.IO.File.Open("3.txt", FileMode.Open))
            {
                long length = new FileInfo("3.txt").Length;
                Console.WriteLine(length);
            }

            // (10b) 2. Jaký je počet znaků v souboru 1.txt, když
            // pomineme bílé znaky?
            // Tip: Struktura Char má statickou funkci IsWhiteSpace().

            using (FileStream fs = System.IO.File.Open("1.txt", FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                int count = 0;
                int c;
                while ((c = sr.Read()) != -1)
                {
                    char znak = (char)c;

                    if (!char.IsWhiteSpace(znak))
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
            }

            using (StreamWriter sw = new StreamWriter("6.txt"))
            {
                sw.WriteLine("1");
                sw.WriteLine("2");
                sw.WriteLine("3");
            }

            using (StreamWriter sw = new StreamWriter("7.txt"))
            {
                sw.Write("1\n2\n3");
            }

            // (5b) 3. Jaké znaky (vypište jako integery) jsou
            // použity pro oddělení řádků v souboru 3.txt?
            // Porovnejte s 4.txt a 5.txt. (Ty jsem nenašel!!)
            // Jakým znakům odpovídají v ASCII tabulce?
            // https://www.ascii-code.com/
            // Zde se stačí podívat do VS Code a napsat sem
            // odpověď, není potřeba nic programovat.
            //13) CR (Carriage Return)
            //10) LF(Line Feed)


            // (10b) 4. Kolik slov má soubor 6.txt?
            // Za slovo teď považujme neprázdnou souvislou
            // posloupnost nebílých znaků oddělené bílými.
            // Tip: Split defaultně odděluje na základě
            // libovolných bílých znaků, ale je tam jeden háček.. jaký? Pokud tam je víc mezer/bílých znaků za sebou, podělá nám to ten soubor.
            // V souboru je vidět 52 slov.

            string text = System.IO.File.ReadAllText("6.txt");
            string[] words = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(words.Length);


            // (15b) 5. Zapište do souboru 7.txt slovo "řeřicha".
            // Povedlo se?
            // Vypište obsah souboru do konzole. V čem je u
            // konzole problém a jak ho spravit? UTF-16
            // Jaké kódování používá C#? Kolik bytů na znak? 2 bajty na znak při UTF-16

            System.IO.File.WriteAllText("7.txt", "řeřicha");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(System.IO.File.ReadAllText("7.txt"));

            // (25b) 6. Vypište četnosti jednotlivých slov v
            // souboru 8.txt do souboru 9.txt ve formátu slovo:četnost na samostatný
            // řádek.
            // Tentokrát však slova nejprve očištěte od diakritiky
            // a všechna písmena berte jako malá (tak je i ukládejte do slovníku).
            // Tip: Využijte slovník: Dictionary<string, int>
            // slova = new Dictionary<string, int>();

            string text_third = System.IO.File.ReadAllText("8.txt").ToLower();


            string bezDiakritiky = new string(
                text_third.Normalize(NormalizationForm.FormD)
                    .Where(c => Char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    .ToArray() //sice super, ale tohle člověk u maturity nedá (nematuruju)
            );

            string[] slova = bezDiakritiky
                .Split((char[])null, StringSplitOptions.RemoveEmptyEntries); //PS: nikdy nebude null v našem případě

            var cetnosti = new Dictionary<string, int>();

            foreach (string s in slova)
            {
                cetnosti[s] = cetnosti.ContainsKey(s) ? cetnosti[s] + 1 : 1;
            }

            using (StreamWriter sw = new StreamWriter("9.txt"))
            {
                foreach (var p in cetnosti)
                    sw.WriteLine($"{p.Key}:{p.Value}");
            }


            // (+15b) Bonus: Vypište četnosti jednotlivých znaků
            // abecedy (malá a velká písmena) v souboru 8.txt do konzole.

            string text_second = System.IO.File.ReadAllText("8.txt");

            var dict = new Dictionary<char, int>();

            foreach (char c in text_second)
            {
                if (char.IsLetter(c))
                {
                    if (dict.ContainsKey(c))
                        dict[c]++;
                    else
                        dict[c] = 1;
                }
            }

            foreach (var pair in dict)
                Console.WriteLine($"{pair.Key}: {pair.Value}");

            #endregion
        }
    }
}

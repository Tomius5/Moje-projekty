using System.Text;

namespace _6._10._cvičná_maturita
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            Console.WriteLine("Zadej input, prosím:");
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int[,] inputMap = new int[width, height];
            for (int i = 0; i < height; i++)   //VYŘEŠIT MEZERY
            {
                string input = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    inputMap[j, i] = input[j];
                }
            }
            Print(inputMap, height, width);
            Clovek pepa = new Clovek();
            pepa.vyska = 45;
            pepa.Pozdrav2();
            Clovek.Pozdrav();
            Clovek cecil = new Clovek();
            Console.ReadLine();
        }
        public static void Print(int[,] whatToPrint, int height, int width)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    stringBuilder.Append(whatToPrint[j, i]);
                }
                stringBuilder.AppendLine();
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }

    class Clovek
    {
        public int vyska;
        public static void Pozdrav() { }

        public  void Pozdrav2() { }
    }

}

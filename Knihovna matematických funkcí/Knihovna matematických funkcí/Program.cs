using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_matematických_funkcí
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class Mathfunction
    {
        public static string Name { get; }
        public static string Description { get; }
        public Interval Domain { get; set; } 
        public Interval Range { get; }
    }
    public struct Interval 
    {
        public double down;
        public double up;
        public // Vyřešit typ závorek.
    }
}

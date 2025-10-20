using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_matematických_funkcí
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = 2; // Pro daný bod
            double y = -2;
            List<MathFunction> funkce = new List<MathFunction>();
            funkce.Add(new LinearFunction(2, 3));
            funkce.Add(new LinearAbsFunction(-1, 4));
            funkce.Add(new RationalLinearFunction(1, 2, 1));
            funkce.Add(new QuadraticFunction(1, -3, 2));
            foreach (var f in funkce)
            {
                Console.WriteLine(f.GetInfo());
                Console.WriteLine("f(" + x + ") = " + f.Calculate(x));
                Console.WriteLine("f(" + y + ") = " + f.Calculate(y));
            }
            Console.ReadLine();
        }
    }
    public abstract class MathFunction
    {
        public string Name;
        public string Description;
        public Interval Domain;
        public Interval Range;

        public abstract double Calculate(double x);

        public string GetInfo()
        {
            return Name + ": " + Description +
                   "   D(f) = " + Domain.ToString() +
                   "   H(f) = " + Range.ToString();
        }

    }
    public struct Interval
    {
        public double down;
        public double up;
        public bool zavDol;
        public bool zavHor;

        public Interval(double d, double u, bool zD = true, bool zH = true)
        {
            down = d;
            up = u;
            zavDol = zD;
            zavHor = zH;
        }

        public override string ToString()
        {
            string l = zavDol ? "[" : "(";
            string r = zavHor ? "]" : ")";
            string d = double.IsNegativeInfinity(down) ? "-nekonečno" : down.ToString();
            string u = double.IsPositiveInfinity(up) ? "nekonečno" : up.ToString();
            return l + d + ", " + u + r;
        }
    }
    
    public class LinearFunction : MathFunction
    {
        public double a, b;
        public LinearFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
            Name = "Lineární funkce";
            Description = "f(x) = " + a + "x + " + b;
            Domain = new Interval(double.NegativeInfinity, double.PositiveInfinity); //Zajímavej způsob, jak zapsat nekonečno 
            Range = new Interval(double.NegativeInfinity, double.PositiveInfinity);
        }

        public override double Calculate(double x)
        {
            return a * x + b;
        }
    }

    public class LinearAbsFunction : MathFunction
    {
        public double a, b;
        public LinearAbsFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
            Name = "Lineární s x v absolutní hodnotě";
            Description = "f(x) = |" + a + "x + " + b + "|";
            Domain = new Interval(double.NegativeInfinity, double.PositiveInfinity);
            Range = new Interval(double.NegativeInfinity, double.PositiveInfinity);
        }
        public override double Calculate(double x)
        {
            return Math.Abs(a * x + b);
        }
    }
    public class RationalLinearFunction : MathFunction
    {
        public double a, b, c;
        public RationalLinearFunction(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            Name = "Lineární lomená funkce";
            Description = "f(x) = (" + a + "x + " + b + ") / (" + c + "x)";
            Domain = new Interval(double.NegativeInfinity, double.PositiveInfinity);
            // Domain = new Interval(double.NegativeInfinity, 0); 
            // Domain = new Interval(0, double.PositiveInfinity);
            // Domain = new Interval(double.NegativeInfinity, double.PositiveInfinity, false, false);
            // Domain = null
        }
        public override double Calculate(double x)
        {
            return (a * x + b) / (c * x);
        }
    }
    public class QuadraticFunction : MathFunction
    {
        public double a, b, c;
        public QuadraticFunction(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            Name = "Kvadratická funkce";
            Description = "f(x) = " + a + "x² + " + b + "x + " + c;
            Domain = new Interval(double.NegativeInfinity, double.PositiveInfinity);
            if (a > 0)
            {
                Range = new Interval(double.NegativeInfinity, double.PositiveInfinity);
            }
            else //Už fakt IDK, jak vyřešit spodek a nechce se mi hledat extrémy...
            {
                Range = new Interval(double.PositiveInfinity, double.NegativeInfinity);
            }

        }
        public override double Calculate(double x)
        {
            if (a == 0)
            {
                Console.WriteLine("Není kvadratická funkce!");
            }
              
            return a * x * x + b * x + c; 
        }
    }
}

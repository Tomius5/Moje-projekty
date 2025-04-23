namespace Vyhodnocovani_vyrazu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int decide = 0;
            while (decide != 1 || decide != 2)
            {
                Console.WriteLine("Ahoj, chceš vyhodnotit výraz ve tvaru prefixu (1) nebo postfixu (2)? 1/2?");
                string? x = Console.ReadLine();
                decide = Convert.ToInt32 (x);
                switch (x)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case null:
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Díky, teď vlož výraz, který chceš vyřešit:");
            string toSolve = Console.ReadLine();
            int solved = Solve.Solve2(toSolve);
        }
    }
    class Solve
    { //Solve2 = Postfix, Solve1 = Prefix
        static public int Solve2(string toSolve)
        {
            string[] words = toSolve.Split(' ');
            Stack<int> stack = new Stack<int>();
            foreach (var thing in words) 
            {
                switch (thing)
                {
                    case "+":
                        int first = stack.Pop();
                        int second = stack.Pop();   
                        int result = first + second;
                        stack.Push(result);
                        break;
                    case "-":
                        int third = stack.Pop();
                        int fourth = stack.Pop();
                        int result2 = fourth - third;
                        stack.Push(result2);
                        break;
                    case "*":
                        int fifth = stack.Pop();
                        int sixth = stack.Pop();
                        int result3 = fifth * sixth;
                        stack.Push(result3);
                        break;
                    case "/":
                        int seventh = stack.Pop();
                        int eight = stack.Pop();
                        int result4 = eight / seventh;
                        stack.Push(result4);
                        break;
                    default:
                        int thing2 = Convert.ToInt32(thing);
                        stack.Push(thing2);
                        break;
                }
            }
            return stack.Pop();
        }
    }
}

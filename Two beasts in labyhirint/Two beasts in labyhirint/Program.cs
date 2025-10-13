using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Beast_in_Labhyrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej input, prosím:");
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int[] monsterPosition = new int[] { 0, 0 };
            char monsterDirection = ' ';

            char[,] maze = new char[width, height];
            List<(int[] pos, char dir)> monsters = new List<(int[] pos, char dir)>();

            for (int i = 0; i < height; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    char c = input[j];
                    maze[j, i] = c;

                    if (c == '<' || c == '>' || c == '^' || c == 'v')
                    {
                        monsters.Add((new int[] { j, i }, c));
                    }
                }
            }

            //int index = Array.IndexOf(maze, ">");
            // Console.WriteLine("Index je:" + index);
            Console.WriteLine("Kontrola vstupu:");
            Print();
            Console.WriteLine("Pozice příšery je:" + monsterPosition[0] + " " + monsterPosition[1]);
            Console.ReadLine();


            (int[] newPos, char newDir) Turn(char[,] maze, int[] monsterPosition, char monsterDirection)
            {
                int x = monsterPosition[0];
                int y = monsterPosition[1];
                maze[x, y] = '.';

                if (monsterDirection == '<')
                {
                    if ((maze[x, y - 1] == 'X' || maze[x - 1, y - 1] == 'X') && maze[x - 1, y] == '.')
                        x -= 1;
                    else if (maze[x, y + 1] == '.')
                        monsterDirection = 'v';
                    else
                        monsterDirection = '^';
                }
                else if (monsterDirection == '^')
                {
                    if ((maze[x + 1, y] == 'X' || maze[x + 1, y - 1] == 'X') && maze[x, y - 1] == '.')
                        y -= 1;
                    else if (maze[x - 1, y] == '.')
                        monsterDirection = '<';
                    else
                        monsterDirection = '>';
                }
                else if (monsterDirection == '>')
                {
                    if ((maze[x, y + 1] == 'X' || maze[x + 1, y + 1] == 'X') && maze[x + 1, y] == '.')
                        x += 1;
                    else if (maze[x, y + 1] == '.')
                        monsterDirection = 'v';
                    else
                        monsterDirection = '^';
                }
                else if (monsterDirection == 'v')
                {
                    if ((maze[x - 1, y] == 'X' || maze[x - 1, y + 1] == 'X') && maze[x, y + 1] == '.')
                        y += 1;
                    else if (maze[x - 1, y] == '.')
                        monsterDirection = '<';
                    else
                        monsterDirection = '>';
                }

                maze[x, y] = monsterDirection;

                return (new int[] { x, y }, monsterDirection);
            }

            void Print()
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        stringBuilder.Append(maze[j, i]);
                    }
                    stringBuilder.AppendLine();
                }
                Console.WriteLine(stringBuilder.ToString());
            }
            for (int step = 0; step < 40; step++)
            {
                for (int m = 0; m < monsters.Count; m++)
                {
                    var (newPos, newDir) = Turn(maze, monsters[m].pos, monsters[m].dir);
                    monsters[m] = (newPos, newDir);
                }

                Console.WriteLine($"{step + 1}. kolo");
                Print();
            }

        }
        class Labhyrint //chtěl jsem to udělat přes ní, ale jelikož jsem neschopnej... 
        {
            int width;
            int height;
            byte[] lastPosition;
            char[,] mazeClass;

            public void Maze(int width, int height)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        ;
                    }
                }
            }
        }
    }

}

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
            for (int i = 0; i < height; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    if (input[j] == '<') // || input[j] == '^' || input[j] == '>' || input[j] == 'v') // Proč tam nejdou použít "dvojité" uvozovky netuším...
                    {
                        monsterPosition = new int[] { j, i };
                        monsterDirection = '<';
                    }
                    if (input[j] == '^')
                    {
                        monsterPosition = new int[] { j, i };
                        monsterDirection = '^';
                    }
                    if (input[j] == '>')
                    {
                        monsterPosition = new int[] { j, i };
                        monsterDirection = '>';
                    }
                    if (input[j] == 'v')
                    {
                        monsterPosition = new int[] { j, i };
                        monsterDirection = 'v';
                    }
                    maze[j, i] = input[j];
                }
            }
            //int index = Array.IndexOf(maze, ">");
            // Console.WriteLine("Index je:" + index);
            Console.WriteLine("Kontrola vstupu:");
            Print();
            Console.WriteLine("Pozice příšery je:" + monsterPosition[0] + " " + monsterPosition[1]);
            Console.ReadLine();
            
            void Turn() //char[,] maze, int[] monsterPosition, char monsterDirection)
            {
                int monsterWidth = monsterPosition[0]; //Pro přehlednost
                int monsterHeight = monsterPosition[1];
                maze[monsterWidth, monsterHeight] = '.';
                if (monsterDirection == '<')
                {
                    if ((maze[monsterWidth, monsterHeight - 1] == 'X' || maze[monsterWidth - 1, monsterHeight - 1] == 'X') && maze[monsterWidth - 1, monsterHeight] == '.')
                    { monsterPosition[0] += -1; } //Pokud chceme jít rovně.
                    else if (maze[monsterWidth, monsterHeight + 1] == '.') // ŠPATNĚ && maze[monsterWidth + 1, monsterHeight + 1] == 'X')
                    { monsterDirection = 'v'; } // Pokud se chceme otočit doleva (za levou rukou)
                    else // if (maze[monsterWidth, monsterHeight - 1] == '.' && maze[monsterWidth - 1, monsterHeight - 1] == 'X')
                    { monsterDirection = '^'; } // Pokud se chceme otočit doprava (za pravou rukou)
                }
                else if (monsterDirection == '^')
                {
                    if ((maze[monsterWidth + 1, monsterHeight] == 'X' || maze[monsterWidth + 1, monsterHeight - 1] == 'X') && maze[monsterWidth, monsterHeight - 1] == '.')
                    { monsterPosition[1] -= 1; } // Pokud chceme jít rovně
                    else if (maze[monsterWidth - 1, monsterHeight] == '.')  // ZBYTEČNĚ: && maze[monsterWidth - 1, monsterHeight - 1] == 'X')
                    { monsterDirection = '<'; }// Pokud se chceme otočit doleva (za levou rukou)
                    else // ZBYTEČNĚ if (maze[monsterWidth, monsterHeight - 1] == '.' && maze[monsterWidth - 1, monsterHeight - 1] == 'X')
                    { monsterDirection = '>'; }// Pokud se chceme otočit doprava (za pravou rukou)
                }
                else if (monsterDirection == '>')
                {
                    if ((maze[monsterWidth, monsterHeight + 1] == 'X' || maze[monsterWidth + 1, monsterHeight + 1] == 'X') && maze[monsterWidth + 1, monsterHeight] == '.')
                    //if (maze[monsterWidth + 1, monsterHeight] == '.' && maze[monsterWidth + 1, monsterHeight + 1] == 'X') //Kdybych potřeboval
                    { monsterPosition[0] += 1; }// Pokud chceme jít rovně
                    else if (maze[monsterWidth, monsterHeight + 1] == '.') //ŠPATNĚ && maze[monsterWidth + 1, monsterHeight] == 'X')
                    { monsterDirection = 'v'; }// Pokud se chceme otočit doleva (za levou rukou)
                    else // ZBYTEČNĚ if (maze[monsterWidth, monsterHeight - 1] == '.' && maze[monsterWidth + 1, monsterHeight] == 'X')
                    { monsterDirection = '^'; }// Pokud se chceme otočit doprava (za pravou rukou)
                }
                else if (monsterDirection == 'v')
                {
                    if ((maze[monsterWidth - 1, monsterHeight] == 'X' || maze[monsterWidth - 1, monsterHeight + 1] == 'X') && maze[monsterWidth, monsterHeight + 1] == '.')
                    { monsterPosition[1] += 1; }// Pokud chceme jít rovně
                    else if (maze[monsterWidth - 1, monsterHeight] == '.') // ŠPATNĚ && maze[monsterWidth - 1, monsterHeight + 1] == 'X')
                    { monsterDirection = '<'; }// Pokud se chceme otočit doleva (za levou rukou)
                    else  // ZBYTEČNÁ PODMÍNKA if (maze[monsterWidth, monsterHeight + 1] == '.' && maze[monsterWidth + 1, monsterHeight + 1] == 'X')
                    { monsterDirection = '>'; }// Pokud se chceme otočit doprava (za pravou rukou)
                }
                int newX = monsterPosition[0];
                int newY = monsterPosition[1];
                maze[newX, newY] = monsterDirection;

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
            for (int i = 0; i < 40; i++)
            {
                Turn();
                Console.WriteLine(i + 1 + ". kolo");
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

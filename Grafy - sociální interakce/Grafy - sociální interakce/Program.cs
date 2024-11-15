namespace Grafy___sociální_interakce
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Zadejte vstup:");
            int n = Convert.ToInt32(Console.ReadLine());
            string friendPairsToBeFixed = Console.ReadLine();
            string[] friendsway = Console.ReadLine().Split();
            int startUser = int.Parse(friendsway[0]);
            int endUser = int.Parse(friendsway[1]);

            bool[,] friendshipMatrix = new bool[n + 1, n + 1];
            string[] friendPairs = friendPairsToBeFixed.Split(' ');

            foreach (var pair in friendPairs)
            {
                string[] friends = pair.Split('-');
                int friend1 = int.Parse(friends[0]);
                int friend2 = int.Parse(friends[1]);

                friendshipMatrix[friend1, friend2] = true;
                friendshipMatrix[friend2, friend1] = true;
            }

            Console.WriteLine("Tabulka přátel pro lepší přehlednost:");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(friendshipMatrix[i, j] ? "1 " : "0 "); // internet a Visual Studio doporučení potahalo
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Hledám řetízek přátelství mezi uživateli {startUser} a {endUser}...");

            string result = FindPath(startUser, endUser, friendshipMatrix, n, $"{startUser}", new bool[n + 1]); // třeba proč se mi tam objevilo $"{startUser}" nevím, Visual Studio moment 
            Console.WriteLine(result);
        }
        static string FindPath(int currentUser, int endUser, bool[,] matrix, int n, string path, bool[] visited)
        {
            if (currentUser == endUser)
            {
                return $"Řetězec je: {path}"; // Rekurzivně se vždy dostaneme k tomuto nebo k tomu na konci
            }

            visited[currentUser] = true; 

            for (int i = 1; i <= n; i++) 
            {
                if (matrix[currentUser, i] && !visited[i]) // Třeba reálně poradilo Visual Studio a já ani nevím, co to dělá ;(((
                {
                    string result = FindPath(i, endUser, matrix, n, $"{path}-{i}", visited); // Rekurze v c# je pain, děkuji za optání
                    if (result.Contains("Řetězec je")) // Pokud najdeme cestu, ukončíme hledání
                    {
                        return result;
                    }
                }
            }

            return "Vazba neexistuje"; 
        }
    }
}

using System.ComponentModel.Design;

Console.WriteLine("Cscs");
int[,] board_diagonal = new int[6, 7]{ //myslím, že v týhle byla chyba, že tam byly 2 výhry naráz, 
    { 0, 0, 0, 0, 1, 0, 0 },           // což by jako nevadilo, ale pro testování jednotlivých funkcí jo
    { 0, 0, 0, 1, 2, 0, 0 },
    { 0, 0, 1, 1, 1, 0, 2 },
    { 0, 1, 1, 2, 2, 2, 1 },
    { 1, 1, 2, 1, 2, 2, 2 },
    { 1, 2, 2, 2, 1, 2, 2 }
};
int[,] board_vertical = new int[6, 7]{
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 0, 0 },
    { 0, 0, 0, 1, 2, 2, 0 },
    { 2, 2, 2, 1, 1, 1, 2 }
};
int[,] board = new int[6, 7]{ //horizonatálně
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 0, 0 },
    { 0, 0, 0, 1, 2, 1, 0 },
    { 2, 2, 2, 2, 2, 1, 0 }
};

static bool Check(int[,] board)
{
    return Horizontals(board) || Verticals(board) || Diagonals(board);
}

static bool Horizontals(int[,] board)
{
    for (int i = 0; i < 6; i++)
    {
        int four = 0;
        int last = 0;
        for (int j = 0; j < 7; j++)
        {
            if (board[i, j] == 0) 
            {
                four = 0;
                last = 0;
            }
            else if (board[i, j] == 1)
            {
                if (last == 1) four++;
                else four = 1;
                last = 1;
            }
            else if (board[i, j] == 2)
            {
                if (last == 2) four--;
                else four = -1;
                last = 2;
            }
            if (four == 4)
            {
                return true;
            }
            if (four == -4)
            {
                return true;
            }
        }
    }
    return false;
}

static bool Verticals(int[,] board)
{
    for (int i = 0; i < 7; i++)
    {
        int four = 0;
        int last = 0;
        for (int j = 0; j < 6; j++)
        {
            if (board[j, i] == 0)
            {
                four = 0;
                last = 0;
            }
            else if (board[j, i] == 1)
            {
                if (last == 1) four++;
                else four = 1;
                last = 1;
            }
            else if (board[j, i] == 2)
            {
                if (last == 2) four--;
                else four = -1;
                last = 2;
            }
            if (four == 4)
            {
                return true;
            }
            if (four == -4)
            {
                return true;
            }
        }
    }
    return false;
}

static bool Diagonals(int[,] board)
{
    for (int r = 0; r < 6; r++)
    {
        for (int c = 0; c < 7; c++)
        {
            int four = 0;
            int last = 0;

            for (int i = 0; r + i < 6 && c + i < 7; i++)
            {
                if (board[r + i, c + i] == 0)
                {
                    four = 0;
                    last = 0;
                }
                else if (board[r + i, c + i] == 1)
                {
                    four += last;
                    last = 1;
                }
                else if (board[r + i, c + i] == 2)
                {
                    four -= last / 2;
                    last = 2;
                }
                if (four == 4 || four == -4)
                {
                    return true;
                }
            }

            four = 0;
            last = 0;

            for (int i = 0; r + i < 6 && c - i >= 0; i++)
            {
                if (board[r + i, c - i] == 0)
                {
                    four = 0;
                    last = 0;
                }
                else if (board[r + i, c - i] == 1)
                {
                    four += last;
                    last = 1;
                }
                else if (board[r + i, c - i] == 2)
                {
                    four -= last / 2;
                    last = 2;
                }
                if (four == 4 || four == -4)
                {
                    return true;
                }
            }
        }
    }
    return false;
}


Console.WriteLine(Check(board_vertical)); 
Console.WriteLine(Check(board_diagonal));
Console.WriteLine(Check(board));

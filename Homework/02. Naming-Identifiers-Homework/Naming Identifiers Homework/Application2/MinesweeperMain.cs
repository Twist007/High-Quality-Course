using System;
using System.Collections.Generic;
using Application2;

namespace mini4ki
{
    public class Minesweeper
    {
        private static void Main()
        {
            const int maxTurns = 35;
            string command;
            char[,] board = CreateBoard();
            char[,] bombs = BombInitialize();
            int countPoints = 0;
            bool isBlow = false;
            List<Raiting> listOfWinners = new List<Raiting>(6);
            int row = 0;
            int col = 0;
            bool isStart = true;
            bool flag2 = false;

            do
            {
                if (isStart)
                {
                    Console.WriteLine(
                        "Lets play minesweeper.Try your luck to finde empty filds."
                        + " Command 'top' show high score, 'restart' start new game, 'exit' escape from game.");
                    dumpp(board);
                    isStart = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        HighScore(listOfWinners);
                        break;
                    case "restart":
                        board = CreateBoard();
                        bombs = BombInitialize();
                        dumpp(board);
                        isBlow = false;
                        isStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                NextTurn(board, bombs, row, col);
                                countPoints++;
                            }

                            if (maxTurns == countPoints)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                dumpp(board);
                            }
                        }
                        else
                        {
                            isBlow = true;
                        }

                        break;
                    default:
                        throw new ArgumentException("Wrong command!");
                        break;
                }

                if (isBlow)
                {
                    dumpp(bombs);
                    Console.Write("\nYou die with {0} points. " + "Enter your nickname: ", countPoints);
                    string nickname = Console.ReadLine();
                    Raiting raiting = new Raiting(nickname, countPoints);
                    if (listOfWinners.Count < 5)
                    {
                        listOfWinners.Add(raiting);
                    }
                    else
                    {
                        for (int i = 0; i < listOfWinners.Count; i++)
                        {
                            if (listOfWinners[i].Points < raiting.Points)
                            {
                                listOfWinners.Insert(i, raiting);
                                listOfWinners.RemoveAt(listOfWinners.Count - 1);
                                break;
                            }
                        }
                    }

                    listOfWinners.Sort((Raiting firstUser, Raiting secUser) => secUser.Name.CompareTo(firstUser.Name));
                    listOfWinners.Sort((Raiting firstUser, Raiting secUser) => secUser.Points.CompareTo(firstUser.Points));
                    HighScore(listOfWinners);

                    board = CreateBoard();
                    bombs = BombInitialize();
                    countPoints = 0;
                    isBlow = false;
                    isStart = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    dumpp(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    Raiting to4kii = new Raiting(imeee, countPoints);
                    listOfWinners.Add(to4kii);
                    HighScore(listOfWinners);
                    board = CreateBoard();
                    bombs = BombInitialize();
                    countPoints = 0;
                    flag2 = false;
                    isStart = true;
                }
            }
            while (command != "exit");
            Console.Read();
        }

        private static void HighScore(List<Raiting> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Emty high score!\n");
            }
        }

        private static void NextTurn(char[,] field, char[,] bombs, int row, int col)
        {
            char numberOfBombs = kolko(bombs, row, col);
            bombs[row, col] = numberOfBombs;
            field[row, col] = numberOfBombs;
        }

        private static void dumpp(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] BombInitialize()
        {
            int rows = 5;
            int columns = 10;
            char[,] board = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    board[row, col] = '-';
                }
            }

            List<int> listOfNumbers = new List<int>();
            while (listOfNumbers.Count < 15)
            {
                Random randomGenerator = new Random();
                int randomNumber = randomGenerator.Next(50);
                if (!listOfNumbers.Contains(randomNumber))
                {
                    listOfNumbers.Add(randomNumber);
                }
            }

            foreach (int num in listOfNumbers)
            {
                int col = num / columns;
                int row = num % columns;
                if (row == 0 && num != 0)
                {
                    col--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        private static void accounts(char[,] fild)
        {
            int col = fild.GetLength(0);
            int row = fild.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (fild[i, j] != '*')
                    {
                        char number = kolko(fild, i, j);
                        fild[i, j] = number;
                    }
                }
            }
        }

        private static char kolko(char[,] r, int rr, int rrr)
        {
            int brojkata = 0;
            int reds = r.GetLength(0);
            int kols = r.GetLength(1);

            if (rr - 1 >= 0)
            {
                if (r[rr - 1, rrr] == '*')
                {
                    brojkata++;
                }
            }

            if (rr + 1 < reds)
            {
                if (r[rr + 1, rrr] == '*')
                {
                    brojkata++;
                }
            }

            if (rrr - 1 >= 0)
            {
                if (r[rr, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if (rrr + 1 < kols)
            {
                if (r[rr, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr - 1 >= 0) && (rrr - 1 >= 0))
            {
                if (r[rr - 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr - 1 >= 0) && (rrr + 1 < kols))
            {
                if (r[rr - 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr + 1 < reds) && (rrr - 1 >= 0))
            {
                if (r[rr + 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr + 1 < reds) && (rrr + 1 < kols))
            {
                if (r[rr + 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            return char.Parse(brojkata.ToString());
        }
    }
}
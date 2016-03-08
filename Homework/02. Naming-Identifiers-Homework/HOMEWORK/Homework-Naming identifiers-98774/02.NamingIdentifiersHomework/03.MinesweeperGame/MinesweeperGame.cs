using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.MinesweeperGame
{
    public class MinesweeperGame
    {
        private static void Main()
        {
            string command = string.Empty;
            char[,] playBoard = CreatePlayFields();
            char[,] bombs = PlantBombs();
            int pointsCounter = 0;
            bool grum = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool isBeginning = true;
            const int Max = 35;
            bool gameWon = false;

            do
            {
                if (isBeginning)
                {
                    Console.WriteLine(
                        "Let's play the game Minesweeper. Try to find the cells without mines."
                        + " The command 'top' shows the ranking, by 'restart' you begin a new game, 'exit' exits the game!");
                    PrintPlayBoard(playBoard);
                    isBeginning = false;
                }

                Console.Write("Enter a row and a column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= playBoard.GetLength(0) && col <= playBoard.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowStats(champions);
                        break;
                    case "restart":
                        playBoard = CreatePlayFields();
                        bombs = PlantBombs();
                        PrintPlayBoard(playBoard);
                        grum = false;
                        isBeginning = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye bye!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                ShowNumberOfBombs(playBoard, bombs, row, col);
                                pointsCounter++;
                            }

                            if (Max == pointsCounter)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                PrintPlayBoard(playBoard);
                            }
                        }
                        else
                        {
                            grum = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nYou entered an invalid command\n");
                        break;
                }

                if (grum)
                {
                    PrintPlayBoard(bombs);
                    Console.Write("\nHrrrrrr! You died with {0} points. " + "Enter you nickname: ", pointsCounter);
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, pointsCounter);
                    if (champions.Count < 5)
                    {
                        champions.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < player.Points)
                            {
                                champions.Insert(i, player);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    ShowStats(champions);

                    playBoard = CreatePlayFields();
                    bombs = PlantBombs();
                    pointsCounter = 0;
                    grum = false;
                    isBeginning = true;
                }

                if (gameWon)
                {
                    Console.WriteLine("\nYou won");
                    PrintPlayBoard(bombs);
                    Console.WriteLine("Enter your name: ");
                    string imeee = Console.ReadLine();
                    Player to4kii = new Player(imeee, pointsCounter);
                    champions.Add(to4kii);
                    ShowStats(champions);
                    playBoard = CreatePlayFields();
                    bombs = PlantBombs();
                    pointsCounter = 0;
                    gameWon = false;
                    isBeginning = true;
                }
            }
            while (command != "exit");
            Console.Read();
        }

        private static void ShowStats(List<Player> to4kii)
        {
            Console.WriteLine("\nPoints:");
            if (to4kii.Count > 0)
            {
                for (int i = 0; i < to4kii.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, to4kii[i].Name, to4kii[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking!\n");
            }
        }

        private static void ShowNumberOfBombs(char[,] playField, char[,] bombs, int row, int col)
        {
            char bombsCount = GetNumberOfBombs(bombs, row, col);
            bombs[row, col] = bombsCount;
            playField[row, col] = bombsCount;
        }

        private static void PrintPlayBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayFields()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlantBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!bombs.Contains(asfd))
                {
                    bombs.Add(asfd);
                }
            }

            foreach (int bomb in bombs)
            {
                int col = bomb / cols;
                int row = bomb % cols;
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playField[col, row - 1] = '*';
            }

            return playField;
        }
        
        private static char GetNumberOfBombs(char[,] playField, int row, int col)
        {
            int count = 0;
            int rows = playField.GetLength(0);
            int cols = playField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playField[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (playField[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (playField[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (playField[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playField[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (playField[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (playField[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (playField[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
﻿using System;
using static Connect4.HumanPlayer;

namespace Connect4
{
    public abstract class Player
    {
        public string Name { get; set; }

        public abstract int MakeMove(Connect4Game game);
    }

    public class HumanPlayer : Player
    {
        public override int MakeMove(Connect4Game game)
        {
            int column;
            do
            {
                Console.Write($"{Name}, choose a column to drop your piece (1-7), or press 'ESC' to exit: ");
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    return -1; // Indicates the player wants to exit
                }



                return column;
            }
    }

        public class AIPlayer : Player
        {
            public override int MakeMove(Connect4Game game)
            {
                int column;
                do
                {
                    Random rnd = new Random();
                    column = rnd.Next(0, 7);
                } while (game.IsColumnFull(column)); // Keep generating a new column until a non-full column is found

                Console.WriteLine($"\n{Name} is thinking...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"\n{Name} dropped its piece into column {column + 1}");

                return column;
            }
        }

        public class Connect4Game
        {
            public int[,] board { get; set; }

            public void DrawBoard()
            {
                Console.WriteLine("Welcome to Connect Four!");
                Console.WriteLine();
                Console.WriteLine(" 1 2 3 4 5 6 7");
                Console.WriteLine("---------------");
                for (int row = 0; row < 6; row++)
                {
                    for (int col = 0; col < 7; col++)
                    {
                        Console.Write("|");
                    }
                    Console.WriteLine("|");
                }
                Console.WriteLine("---------------");
                Console.WriteLine(" 1 2 3 4 5 6 7");
            }

            public bool IsValidMove(int column)
            {
                return column >= 0 && column < 7 && board[0, column] == 0;
            }

            public bool IsColumnFull(int column)
            {


                return true; // Column is full
            }

            public int GetNextOpenRow(int column)
            {
                for (int row = 5; row >= 0; row--)
                {
                    if (board[row, column] == 0)
                    {
                        return row;
                    }
                }
                return -1; // Error: column is full
            }

            public bool IsWinningMove(int row, int col)
            {
                int player = board[row, col];
                int count = 0;

                // Check horizontal
                for (int j = 0; j < 7; j++)
                {
                    if (board[row, j] == player)
                    {
                        count++;
                        if (count == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }

                // Check vertical
                count = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (board[i, col] == player)
                    {
                        count++;
                        if (count == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }




                return false;
            }

            public bool IsBoardFull()
            {
                for (int col = 0; col < 7; col++)
                {
                    if (board[0, col] == 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            public int GetNextAIMove()
            {
                int column;


                return column;
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Connect4Game connect4 = new Connect4Game();
                connect4.board = new int[6, 7];

                int currentPlayer = 1;
                int aiPlayer = 2;
                bool isGameOver = false;
                bool againstAI = false;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome to");
                Console.WriteLine(@"  ______   ______   .__   __. .__   __.  _______   ______ .___________.    _  _    ");
                Console.WriteLine(@" /      | /  __  \  |  \ |  | |  \ |  | |   ____| /      ||           |   | || |   ");
                Console.WriteLine(@"|  ,----'|  |  |  | |   \|  | |   \|  | |  |__   |  ,----'`---|  |----`   | || |_  ");
                Console.WriteLine(@"|  |     |  |  |  | |  . `  | |  . `  | |   __|  |  |         |  |        |__   _| ");
                Console.WriteLine(@"|  `----.|  `--'  | |  |\   | |  |\   | |  |____ |  `----.    |  |           | |   ");
                Console.WriteLine(@" \______| \______/  |__| \__| |__| \__| |_______| \______|    |__|           |_|   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Please choose the player mode:");
                Console.WriteLine("1. Human vs. Human");
                Console.WriteLine("2. Human vs. Computer");

                int modeChoice;
                do
                {
                    Console.Write("Enter the mode number (1 or 2): ");
                } while (!int.TryParse(Console.ReadLine(), out modeChoice) || modeChoice < 1 || modeChoice > 2);

                switch (modeChoice)
                {
                    case 1:
                        againstAI = false;
                        break;
                    case 2:
                        againstAI = true;
                        break;
                }

                string player1Name, player2Name;
                Console.Write("Enter Player 1's name: ");
                player1Name = Console.ReadLine();

                player2Name = "Computer";
            }

            while (!isGameOver)
            {
                Console.Clear();
                connect4.DrawBoard();


                    Console.Write($"\n{GetPlayerName(currentPlayer, player1Name, player2Name)}, choose a column to drop your piece (1-7), or press 'ESC' to exit: ");
                    var key = Console.ReadKey(true);


        }

        Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }

    private static string GetPlayerName(int currentPlayer, string player1Name, string player2Name)
    {
        return currentPlayer == 1 ? player1Name : player2Name;
    }
}
}

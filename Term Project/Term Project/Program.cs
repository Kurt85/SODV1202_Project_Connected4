using System;

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
                // Error handling for exceptional input e.g. string or other numbers
                if (int.TryParse(key.KeyChar.ToString(), out column))
                {
                    column -= 1;
                    if (!game.IsValidMove(column))
                    {
                        Console.WriteLine("\nInvalid move. Please try again.");
                        if (game.IsColumnFull(column))
                        {
                            Console.WriteLine("\nSelected column is full. Please choose another column.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please try again.");
                }
            } while (!game.IsValidMove(column));

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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to Connect 4!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" 1 2 3 4 5 6 7");
            Console.WriteLine("---------------");
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("|");
                    if (board[row, col] == 0)
                    {
                        Console.Write(" ");
                    }
                    else if (board[row, col] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else if (board[row, col] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------------");
            Console.WriteLine(" 1 2 3 4 5 6 7");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool IsValidMove(int column)
        {

            return column >= 0 && column < 7 && board[0, column] == 0;
        }

        public bool IsColumnFull(int column)
        {
            if (column < 0 || column >= 7)
            {
                return true; // Column number is outside of valid range
            }

            for (int row = 0; row < 6; row++)
            {
                if (board[row, column] == 0)
                {
                    return false; // Found an empty spot in this column
                }
            }

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

            // Check diagonal
            count = 0;
            for (int i = -3; i <= 3; i++)
            {
                int r = row + i;
                int c = col + i;
                if (r >= 0 && r < 6 && c >= 0 && c < 7)
                {
                    if (board[r, c] == player)
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
            }

            // Check anti-diagonal
            count = 0;
            for (int i = -3; i <= 3; i++)
            {
                int r = row + i;
                int c = col - i;
                if (r >= 0 && r < 6 && c >= 0 && c < 7)
                {
                    if (board[r, c] == player)
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
            do
            {
                Random rnd = new Random();
                column = rnd.Next(0, 7);
            } while (IsColumnFull(column)); // Keep generating a new column until a non-full column is found

            return column;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

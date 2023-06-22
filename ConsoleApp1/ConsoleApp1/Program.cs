using System;

namespace Connect4
{
    class Program
    {
        static char[,] board = new char[6, 7]; // The game board
        static bool isGameOver = false; // Indicates if the game is over
        static char currentPlayer; // Current player (X or O)

        static void Main(string[] args)
        {
            InitializeBoard();
            Console.WriteLine("Welcome to Connect 4!");

            while (!isGameOver)
            {
                DrawBoard();
                if (currentPlayer == 'X')
                {
                    Console.WriteLine("Player X, enter your column (0-6): ");
                    int column = GetValidColumn();
                    MakeMove(column, currentPlayer);
                }
                else
                {
                    Console.WriteLine("Computer's turn:");
                    int column = GetComputerMove();
                    MakeMove(column, currentPlayer);
                }

                if (CheckForWin(currentPlayer))
                {
                    DrawBoard();
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    isGameOver = true;
                }
                else if (IsBoardFull())
                {
                    DrawBoard();
                    Console.WriteLine("It's a draw!");
                    isGameOver = true;
                }
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
            }

            Console.WriteLine("Game Over!");
            Console.ReadLine();
        }

        static void InitializeBoard()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    board[row, col] = ' ';
                }
            }

            currentPlayer = 'X';
        }

        static void DrawBoard()
        {
            Console.Clear();

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.Write($"| {board[row, col]} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  0   1   2   3   4   5   6 ");
        }

        static int GetValidColumn()
        {
            int column;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out column) && column >= 0 && column <= 6 && board[0, column] == ' ')
                {
                    return column;
                }
                else
                {
                    Console.WriteLine("Invalid column! Please try again.");
                }
            }
        }

        static void MakeMove(int column, char player)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, column] == ' ')
                {
                    board[row, column] = player;
                    break;
                }
            }
        }

        static bool CheckForWin(char player)
        {
            // Check rows for a win
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] == player && board[row, col + 1] == player &&
                        board[row, col + 2] == player && board[row, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check columns for a win
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (board[row, col] == player && board[row + 1, col] == player &&
                        board[row + 2, col] == player && board[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonals (top-left to bottom-right) for a win
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] == player && board[row + 1, col + 1] == player &&
                        board[row + 2, col + 2] == player && board[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonals (bottom-left to top-right) for a win
            for (int row = 3; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] == player && board[row - 1, col + 1] == player &&
                        board[row - 2, col + 2] == player && board[row - 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool IsBoardFull()
        {
            for (int col = 0; col < 7; col++)
            {
                if (board[0, col] == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        static int GetComputerMove()
        {
            // Check if the computer can win in the next move
            for (int col = 0; col < 7; col++)
            {
                if (IsValidMove(col))
                {
                    MakeMove(col, 'O');
                    if (CheckForWin('O'))
                    {
                        UndoMove(col);
                        return col;
                    }
                    UndoMove(col);
                }
            }

            // Check if the player can win in the next move and block it
            for (int col = 0; col < 7; col++)
            {
                if (IsValidMove(col))
                {
                    MakeMove(col, 'X');
                    if (CheckForWin('X'))
                    {
                        UndoMove(col);
                        return col;
                    }
                    UndoMove(col);
                }
            }

            // Choose a random valid move
            Random random = new Random();
            int column;
            do
            {
                column = random.Next(0, 7);
            }
            while (!IsValidMove(column));

            return column;
        }

        static bool IsValidMove(int column)
        {
            return column >= 0 && column <= 6 && board[0, column] == ' ';
        }

        static void UndoMove(int column)
        {
            for (int row = 0; row < 6; row++)
            {
                if (board[row, column] != ' ')
                {
                    board[row, column] = ' ';
                    break;
                }
            }
        }
    }
}

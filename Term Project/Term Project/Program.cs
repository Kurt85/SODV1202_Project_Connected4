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
           
        }
    }

    public class AIPlayer : Player
    {
        public override int MakeMove(Connect4Game game)
        {
           
        }
    }

    public class Connect4Game
    {
        public int[,] board { get; set; }

        public void DrawBoard()
        {


        public bool IsValidMove(int column)
        {
            return column >= 0 && column < 7 && board[0, column] == 0;
        }

        public bool IsColumnFull(int column)
        {
           
        }

        public int GetNextOpenRow(int column)
        {
            
        }

        public bool IsWinningMove(int row, int col)
        {
            int player = board[row, col];
            int count = 0;

            
        }

        public bool IsBoardFull()
        {
            
        }

        public int GetNextAIMove()
        {
            
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

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

    }
}

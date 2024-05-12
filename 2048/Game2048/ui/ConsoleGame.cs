using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048.ui
{
    public class ConsoleGame
    {
        private const int EmptyCellValue = 0;
        private logic.Game _game;
        public ConsoleGame(logic.Game game)
        {
            _game = game;
        }
        public void DisplayBoard()
        {
            Console.Clear();
            for (int row = 0; row < _game.GameBoard.Data.GetLength(0); row++)
            {
                Console.WriteLine("+------+------+------+------+");
                Console.Write("| ");
                for (int col = 0; col < _game.GameBoard.Data.GetLength(1); col++)
                {
                    if (_game.GameBoard.GetCellValue(new logic.Pos(row, col)) == EmptyCellValue)
                    {
                        const string empty = " ";
                        Console.Write(empty.PadRight(4));
                    }
                    else
                    {
                        int value = _game.GameBoard.GetCellValue(new logic.Pos(row, col));
                        ConsoleColor consoleColor = this.GetNumberColor(value);
                        Console.ForegroundColor = consoleColor;
                        Console.Write(value.ToString().PadRight(4));
                        Console.ResetColor();
                    }

                    Console.Write(" | ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("+------+------+------+------+\n\n");
            PointsMessage();

        }

        public ConsoleKeyInfo ValidateInitInput()
        {
            while (true)
            {
                Console.WriteLine("start a game - enter spacebar '\n' " +
                                  "end program enter ENTER");
                ConsoleKeyInfo input = Console.ReadKey(true); // BLOCKING TO WAIT FOR INPUT

                if (input.Key != ConsoleKey.Enter &&
                     input.Key != ConsoleKey.Spacebar)
                {
                    Console.WriteLine("Press only ENTER or SPACE. Try again");
                    continue;
                }
                return input;
            }
        }
        public ConsoleKeyInfo ValidateUserKeyInput()
        {
            while (true)
            {
                Console.WriteLine("Use arrow keys to move the cells by specific direction");
                ConsoleKeyInfo input = Console.ReadKey(true); // BLOCKING TO WAIT FOR INPUT

                if (input.Key != ConsoleKey.UpArrow &&
                     input.Key != ConsoleKey.DownArrow &&
                     input.Key != ConsoleKey.LeftArrow &&
                     input.Key != ConsoleKey.RightArrow)
                {
                    Console.WriteLine("Press only arrow keys. Try again");
                    continue;
                }
                return input;
            }

        }

        public void PointsMessage()
        {
            Console.WriteLine("Points: " + _game.Points);
        }
        public void WinMessage()
        {
            Console.WriteLine("Congratulations! you won!");
            Console.WriteLine(string.Format("You've reached a {} value cell", _game.winCellValue));
        }
        public void LoseMessage()
        {
            Console.WriteLine("Game over, you lost...");
        }

        public void StartMessage()
        {
            Console.WriteLine("Welcome to the game 2048: ");

        }
        private ConsoleColor GetNumberColor(int num)
        {
            switch (num)
            {
                case 0:
                    return ConsoleColor.DarkGray;
                case 2:
                    return ConsoleColor.Cyan;
                case 4:
                    return ConsoleColor.Magenta;
                case 8:
                    return ConsoleColor.Red;
                case 16:
                    return ConsoleColor.Green;
                case 32:
                    return ConsoleColor.Yellow;
                case 64:
                    return ConsoleColor.Yellow;
                case 128:
                    return ConsoleColor.DarkCyan;
                case 256:
                    return ConsoleColor.Cyan;
                case 512:
                    return ConsoleColor.DarkMagenta;
                case 1024:
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.Red;
            }
        }
    }
}



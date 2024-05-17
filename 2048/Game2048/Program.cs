using System;

namespace Game2048
{
    class Program
    {
        public static void ManageGame()
        {
            UI.ConsoleGame.StartMessage();
            ConsoleKeyInfo input = UI.ConsoleGame.ValidateInitInput();

            switch (input.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("Goodbye...");
                    return;
                case ConsoleKey.Spacebar:
                    GameManager manageGame = new GameManager();
                    manageGame.StartGame();
                    ManageGame();
                    break;
                default:
                    return;
            }
        }
        static void Main(string[] args)
        {
            ManageGame();
        }
    }
}

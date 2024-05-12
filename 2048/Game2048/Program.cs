using System;

namespace Game2048
{
    class Program
    {
        public static ConsoleKeyInfo ValidateInitInput()
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
        public static void StartMessage()
        {
            Console.WriteLine("Welcome to the game 2048: ");
            Console.WriteLine();

        }
        public static void ManageGame()
        {
            StartMessage();
            ConsoleKeyInfo input = ValidateInitInput();

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
            ////logic.Board board = new logic.Board();
            ////board.Initalize();
            ////// board.MoveVertically(logic.Direction.Down); //works
            ////Console.WriteLine(board.Move(logic.Direction.Right));
            //logic.Game game = new logic.Game();

            //game.Move(logic.Direction.Down);
            ////game.Move(logic.Direction.Up);
            ////game.Move(logic.Direction.Left);
            ////game.Move(logic.Direction.Left);
            //ui.ConsoleGame consoleGame = new ui.ConsoleGame(game);
            //consoleGame.ValidateUserKeyInput("a");



            ManageGame();


        }
    }
}

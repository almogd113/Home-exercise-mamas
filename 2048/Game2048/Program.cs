using System;

namespace Game2048
{
    class Program
    {
        static void Main(string[] args)
        {
            logic.Board board = new logic.Board();
            board.Initalize();
            // board.MoveVertically(logic.Direction.Down); //works
            Console.WriteLine(board.Move(logic.Direction.Right));
            logic.Game game = new logic.Game();
        
            game.Move(logic.Direction.Down);
            game.Move(logic.Direction.Up);
            game.Move(logic.Direction.Left);
            game.Move(logic.Direction.Left);



        }
    }
}

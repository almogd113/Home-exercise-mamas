﻿using System;

namespace Game2048
{
    class Program
    {
        static void Main(string[] args)
        {
            logic.Board board = new logic.Board();
            board.Initalize();
            // board.MoveVertically(logic.Direction.Down); //works
            board.MoveHorizantlly(logic.Direction.Right);

        }
    }
}

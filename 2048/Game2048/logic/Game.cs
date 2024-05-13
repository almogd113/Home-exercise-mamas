using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048.Logic
{
    public class Game
    {
        public Board GameBoard
        { get; private set; }

        public GameStatus GameStatus
        { get; set; }

        public int Points
        { get; protected set; }


        public int WinCellValue
            { get; private set; }
        public Game()
        {
            // initialize game data members
            GameBoard = new Board();
            GameBoard.Initalize();
            GameStatus = GameStatus.Idle;
            Points = 0;
            WinCellValue = 2048;
        }
        public void Move(Direction direction)
        {
            if (GameStatus == GameStatus.Idle)
            {

                int pointPerMove = GameBoard.Move(direction);
                Points += pointPerMove;
                UpdatingGameStatus();
            }
        }

        public void UpdatingGameStatus()
        {
            if (IsWin())
            {
                GameStatus = GameStatus.Win;
            }
            else if (IsLose())
            {
                GameStatus = GameStatus.Lose;
            }
            else
                GameStatus = GameStatus.Idle;

        }

        private bool IsLose()
        {
            return this.TestMove();
        }

        private bool IsWin()
        {
            //check if there is cell with the value 2048
            return GameBoard.MaxValueCell >= WinCellValue;
        }

        private bool TestMove()
        {
            Board cloneBoard = new Board(GameBoard);
            if (GameBoard.GetNumberEmptyCells() == 0) //the board is full
            {
                int checkSumPoints = cloneBoard.Move(Direction.Up) + cloneBoard.Move(Direction.Down) +
                    cloneBoard.Move(Direction.Right) + cloneBoard.Move(Direction.Left);

                if (checkSumPoints == 0 && GameBoard.IsBoardIdentical(cloneBoard))
                {
                    return true; // there are no optional moves to do
                }
            }
            return false; // move is possible

        }
    }
}

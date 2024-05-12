using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048
{
    public class GameManager
    {
        private logic.Game _game;
        private ui.ConsoleGame _consoleGame;

        public GameManager()
        {
            _game = new logic.Game();
            _consoleGame = new ui.ConsoleGame(_game);

        }

        public void ManageGame()
        {
            _consoleGame.StartMessage();
            ConsoleKeyInfo input = _consoleGame.ValidateInitInput();

            switch(input.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("Goodbye...");
                    return;
                case ConsoleKey.Spacebar:
                    StartGame();
                    break;
                default:
                    return;
            }
        }
        public void StartGame()
        {
            _consoleGame.DisplayBoard(); //display the init board data
            while (_game.GameStatus == logic.GameStatus.Idle)
            {
                ConsoleKeyInfo userKey = _consoleGame.ValidateUserKeyInput();
                logic.Direction userDirection = GetDirectionByKey(userKey);
                _game.Move(userDirection);
                _consoleGame.DisplayBoard();
            }
            FinalGameStatus();
            
        }

        public void FinalGameStatus()
        {
            switch(_game.GameStatus)
            {
                case logic.GameStatus.Win:
                    _consoleGame.WinMessage();
                    break;
                case logic.GameStatus.Lose:
                    _consoleGame.LoseMessage();
                    break;
                default:
                    _consoleGame.LoseMessage();
                    break;
            }
        }
        public logic.Direction GetDirectionByKey(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    return logic.Direction.Up;

                case ConsoleKey.DownArrow:
                    return logic.Direction.Down;

                case ConsoleKey.LeftArrow:
                    return logic.Direction.Left;

                case ConsoleKey.RightArrow:
                    return logic.Direction.Right;
                default:
                    return logic.Direction.Up;

            }
        }


    }
}

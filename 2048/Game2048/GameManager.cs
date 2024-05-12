using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048
{
    public class GameManager
    {
        private Logic.Game _game;
        private UI.ConsoleGame _consoleGame;

        public GameManager()
        {
            _game = new Logic.Game();
            _consoleGame = new UI.ConsoleGame(_game);

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
                    ManageGame();
                    break;
                default:
                    return;
            }
        }
        public void StartGame()
        {
            _consoleGame.DisplayBoard(); //display the init board data
            while (_game.GameStatus == Logic.GameStatus.Idle)
            {
                ConsoleKeyInfo userKey = _consoleGame.ValidateUserKeyInput();
                Logic.Direction userDirection = GetDirectionByKey(userKey);
                _game.Move(userDirection);
                _consoleGame.DisplayBoard();
            }
            FinalGameStatus();
            
        }

        
        public void FinalGameStatus()
        {
            switch(_game.GameStatus)
            {
                case Logic.GameStatus.Win:
                    _consoleGame.WinMessage();
                    break;
                case Logic.GameStatus.Lose:
                    _consoleGame.LoseMessage();
                    break;
                default:
                    _consoleGame.LoseMessage();
                    break;
            }
        }
        public Logic.Direction GetDirectionByKey(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    return Logic.Direction.Up;

                case ConsoleKey.DownArrow:
                    return Logic.Direction.Down;

                case ConsoleKey.LeftArrow:
                    return Logic.Direction.Left;

                case ConsoleKey.RightArrow:
                    return Logic.Direction.Right;
                default:
                    return Logic.Direction.Up;

            }
        }


    }
}

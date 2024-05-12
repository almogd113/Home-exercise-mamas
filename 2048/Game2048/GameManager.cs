using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048
{
    public class GameManager
    {
        public Logic.Game Game
        { get; private set; }
        public UI.ConsoleGame ConsoleGame
        { get; private set; }

        public GameManager()
        {
            Game = new Logic.Game();
            ConsoleGame = new UI.ConsoleGame(Game);

        }

       
        public void StartGame()
        {
            ConsoleGame.DisplayBoard(); //display the init board data
            while (Game.GameStatus == Logic.GameStatus.Idle)
            {
                ConsoleKeyInfo userKey = ConsoleGame.ValidateUserKeyInput();
                Logic.Direction userDirection = GetDirectionByKey(userKey);
                Game.Move(userDirection);
                ConsoleGame.DisplayBoard();
            }
            FinalGameStatus();
            
        }

        
        public void FinalGameStatus()
        {
            switch(Game.GameStatus)
            {
                case Logic.GameStatus.Win:
                    ConsoleGame.WinMessage();
                    break;
                case Logic.GameStatus.Lose:
                    ConsoleGame.LoseMessage();
                    break;
                default:
                    ConsoleGame.LoseMessage();
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

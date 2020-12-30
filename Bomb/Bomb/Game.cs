using System;
using System.Collections.Generic;

namespace Bomb
{
    public static class Game
    {
        public delegate void GameEventHandler();
        public static GameEventHandler gameEventHandler;

        public delegate void GameEventHandlerWithInteger(int attempts);
        public static GameEventHandlerWithInteger gameEventHandlerWithInteger;

        public static event GameEventHandlerWithInteger BombDisabled;
        public static event GameEventHandler NoMoreAttempts;

        private static Result result;

        private static int timeInSeconds;
        private static int numberOfAttempts;
        private static int menuChoice;

        public static string survivorName;

        public static void StartGame()
        {
            Console.WriteLine(Resources.TextOfAttemps);
            Validation.ValidateInput(out numberOfAttempts);

            Console.WriteLine(Resources.TextOfSeconds);
            Validation.ValidateInput(out timeInSeconds);

            Bomb bomb = new Bomb(timeInSeconds);

            PasswordGuesser passwordGuesser = new PasswordGuesser(bomb, numberOfAttempts);

            BombDisabled = bomb.HandleBombDisabled;
            NoMoreAttempts = bomb.HandleNoMoreAttempts;

            bomb.RunTimer(passwordGuesser);

            Console.Clear();
            StartMenu();
        }

        public static void CreateResult(int seconds, int attemps)
        {
            Console.WriteLine(Resources.TextOfInputName);
            survivorName = Validation.ValidateInput();
            result = new Result { Name = survivorName, SecondsSpent = seconds, AttemptSpent = attemps };
            DataJsonProcessor.AddResultToJsonFile(result);
        }

        public static void StartMenu()
        {
            Console.WriteLine(Resources.TextOfMenu);
            menuChoice = Validation.ValidateInputMenuItem();

            switch (menuChoice)
            {
                case (int)MenuItem.PlayGame:
                    StartGame();
                    break;

                case (int)MenuItem.LookListOfResult:
                    PrintListOfResults();
                    break;

                case (int)MenuItem.EndGame:
                    break;
            }
        }

        public static void PrintListOfResults()
        {
            Console.Clear();
            Console.WriteLine(Resources.ListItem, Resources.TextOfNameСolumn, Resources.TextOfSecondsСolumn, Resources.TextOfAttemptsСolumn);

            List<Result> results = DataJsonProcessor.LoadJson();
            foreach (Result res in results)
            {
                Console.WriteLine(Resources.ListItem, res.Name, res.SecondsSpent, res.AttemptSpent);
            }

            StartMenu();
        }

        public static void OnBombDisabled(int attempts)
        {
            gameEventHandlerWithInteger = BombDisabled;

            if (gameEventHandlerWithInteger != null)
            {
                gameEventHandlerWithInteger(attempts);
            }
        }

        public static void OnNoMoreAttempts()
        {
            gameEventHandler = NoMoreAttempts;

            if (gameEventHandler != null)
            {
                gameEventHandler();
            }
        }
    }
}

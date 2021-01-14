using System;
using System.Collections.Generic;

namespace Bomb
{
    public static class Game
    {
        public delegate void GameEventHandler();

        public delegate void GameEventHandlerWithInteger(int attempts);

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
            numberOfAttempts = Validation.ValidateInput();

            Console.WriteLine(Resources.TextOfSeconds);
            timeInSeconds = Validation.ValidateInput();

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
            survivorName = Validation.ValidateInputName();
            result = new Result { Name = survivorName, SecondsSpent = seconds, AttemptSpent = attemps };
            JsonDataProcessor.AddResultToJsonFile(result);
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
                    ShowListOfResults();
                    break;

                case (int)MenuItem.EndGame:
                    break;
            }
        }

        public static void ShowListOfResults()
        {
            Console.Clear();
            Console.WriteLine(Resources.ListItem, Resources.TextOfNameСolumn, Resources.TextOfSecondsСolumn, Resources.TextOfAttemptsСolumn);

            List<Result> results = JsonDataProcessor.LoadJson();
            foreach (Result res in results)
            {
                Console.WriteLine(Resources.ListItem, res.Name, res.SecondsSpent, res.AttemptSpent);
            }

            StartMenu();
        }

        public static void OnBombDisabled(int attempts)
        {
            BombDisabled?.Invoke(attempts);
        }

        public static void OnNoMoreAttempts()
        {
            NoMoreAttempts?.Invoke();
        }
    }
}

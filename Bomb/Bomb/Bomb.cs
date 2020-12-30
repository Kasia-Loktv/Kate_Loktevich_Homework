using System;
using System.Threading;

namespace Bomb
{
    public class Bomb
    {
        private const int PasswordLength = 4;
        private const int MillisecondsPerSecond = 1000;

        public string Password { get; private set; }

        private int timer;
        private int counterOfTimer;
        private int attemptsSpent;

        private bool isDisabled;
        private bool isNoAttempts;

        private Random random;

        public Bomb(int seconds)
        {
            Password = SetPassword();
            timer = seconds;
            isDisabled = false;
            isNoAttempts = true;
        }

        private string SetPassword()
        {
            random = new Random();
            for (int i = 0; i < PasswordLength; i++)
            {
                Password += random.Next(0, 10).ToString();
            }
            return Password;
        }

        public void RunTimer(PasswordGuesser guesser)
        {
            while (!isDisabled && isNoAttempts && counterOfTimer < timer)
            {
                Thread.Sleep(MillisecondsPerSecond);
                counterOfTimer++;
            }

            if (!isDisabled && isNoAttempts)
            {
                Console.WriteLine(Resources.DetonationMessage + Resources.MenuMessage);

                guesser.ThreadGuesser.Interrupt();
                guesser.IsStop = true;
                guesser.ThreadGuesser.Join();
            }
            else if (!isNoAttempts)
            {
                Console.WriteLine(Resources.DetonationMessage + Resources.MenuMessage);
                Console.ReadLine();
            }
            else
            {
                Game.CreateResult(counterOfTimer, attemptsSpent);
            }
        }

        public void HandleBombDisabled(int attemps)
        {
            isDisabled = true;
            attemptsSpent = attemps;
        }

        public void HandleNoMoreAttempts()
        {
            isNoAttempts = false;
        }
    }
}

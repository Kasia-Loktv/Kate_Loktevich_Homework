using System;
using System.Threading;

namespace Bomb
{
    public class PasswordGuesser
    {
        public Thread ThreadGuesser { get; set; }

        public bool IsStop { get; set; }

        private readonly int numberOfAttempts;
        private int attemptsUsed;

        private string password;
        private string possiblePassword;

        public PasswordGuesser(Bomb bomb, int attempts)
        {
            numberOfAttempts = attempts;
            IsStop = false;

            ThreadGuesser = new Thread(new ParameterizedThreadStart(EnterPassword));
            ThreadGuesser.Start(bomb.Password);
        }

        public void EnterPassword(object obj)
        {
            password = (string)obj;

            Console.Clear();
            Console.WriteLine(Resources.TextOfPassword);
            possiblePassword = Console.ReadLine();

            for (int i = 1; i <= numberOfAttempts; i++)
            {
                attemptsUsed++;

                if (!IsStop)
                {
                    if (possiblePassword == password)
                    {
                        Console.WriteLine(Resources.WinMessage);
                        Game.OnBombDisabled(attemptsUsed);
                        break;
                    }
                    else if (possiblePassword != password && i != numberOfAttempts)
                    {
                        Console.WriteLine(Resources.InvalidPasswordMessage);
                        possiblePassword = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(Resources.NoAttempsMessage);
                        Game.OnNoMoreAttempts();
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}

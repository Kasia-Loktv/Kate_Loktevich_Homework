using System;

namespace Princess
{
    public class Game
    {
        private const int NumberOfRows = 10;
        private const int NumberOfSlashes = 11;

        private const string SeparatorOfRows = "------------------------------------------";
        private const string Slash = "| ";
        private const string PrinceSymbol = "X ";
        private const string PrincessSymbol = "P ";
        private const string StarSymbol = "*";

        private const string FinalText = "Возвращайся скорее, другие принцессы также ждут, когда ты их спасешь";
        private const string Win = "ВЫ ПОБЕДИЛИ!!!  Принцесса спасена \nЖелаете ли вы спасти еще одну принцессу?\n1) Да, нужно спасти больше принцесс\n2) Нет, с меня хватит, я устал";
        private const string Loss = "ВЫ ПРОИГРАЛИ \nЖелаете ли вы еще раз попробовать спасти принцессу?\n1) Да, я должен ее спасти\n2) Нет, думаю, придет другой принц и спасет её";

        private string[,] traps;
        private bool isStart;
        private bool isContinue;
        private bool conditionEndGame;
        private bool isParsed;
        private int endChoice;

        private Random random;

        private Prince prince;

        public void PlayGame()
        {
            isStart = true;

            while (isStart)
            {
                traps = new string[11, 11];
                prince = new Prince();

                SetTraps();

                isContinue = true;

                while (isContinue)
                {
                    PrintField();

                    prince.PrintHP();

                    MovePrince();
                    ReduceHP();
                    FinishGame();
                }
            }
        }

        public void SetTraps()
        {
            random = new Random();

            for (int i = 0; i <= 9; i++)
            {
                traps[random.Next(1, 11), random.Next(1, 11)] = StarSymbol;
            }
        }

        public void PrintField()
        {
            for (int row = 1; row <= NumberOfRows; row++)
            {
                Console.WriteLine(SeparatorOfRows);

                for (int column = 1; column <= NumberOfSlashes; column++)
                {
                    Console.Write(Slash);

                    if (column == prince.XPrince && row == prince.YPrince)
                    {
                        Console.Write(PrinceSymbol);
                    }
                    else if (row == 10 && column == 10)
                    {
                        Console.Write(PrincessSymbol);
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine(SeparatorOfRows);
        }

        public void MovePrince()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (prince.YPrince == 1)
                    {
                        break;
                    }
                    prince.YPrince -= 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (prince.YPrince == 10)
                    {
                        break;
                    }
                    prince.YPrince += 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (prince.XPrince == 1)
                    {
                        break;
                    }
                    prince.XPrince -= 1;
                    break;

                case ConsoleKey.RightArrow:
                    if (prince.XPrince == 10)
                    {
                        break;
                    }
                    prince.XPrince += 1;
                    break;
            }

            Console.SetCursorPosition(0, 0);
        }

        public void ReduceHP()
        {
            random = new Random();

            if (traps[prince.XPrince, prince.YPrince] == StarSymbol)
            {
                prince.HP -= random.Next(1, 11);
            }
        }

        public void FinishGame()
        {
            conditionEndGame = false;

            if (prince.HP <= 0)
            {
                Console.Clear();
                Console.WriteLine(Loss);
                conditionEndGame = true;
            }

            if (prince.XPrince == 10 && prince.YPrince == 10)
            {
                Console.Clear();
                Console.WriteLine(Win);
                conditionEndGame = true;
            }

            if (conditionEndGame)
            {
                endChoice = 0;
                isParsed = false;

                while (!isParsed)
                {
                    isParsed = int.TryParse(Console.ReadLine(), out endChoice);

                    if (endChoice != 1 && endChoice != 2)
                    {
                        isParsed = false;
                    }
                }

                switch (endChoice)
                {
                    case 1:
                        isContinue = false;
                        Console.Clear();
                        break;

                    case 2:
                        isContinue = false;
                        isStart = false;
                        Console.Clear();
                        Console.WriteLine(FinalText);
                        break;
                }
            }
        }
    }
}

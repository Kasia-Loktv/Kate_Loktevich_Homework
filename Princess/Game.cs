using System;

namespace Princess
{
    public class Game
    {
        private const int numberOfRows = 10;
        private const int numberOfSlashes = 11;

        private const string separatorOfRows = "------------------------------------------";
        private const string finalText = "Возвращайся скорее, ещё много принцесс ждут, когда ты их спасешь";
        private const string win = "ВЫ ПОБЕДИЛИ!!!  Принцесса спасена \nЖелаете ли вы спасти еще одну принцессу?\n1) Да, нужно спасти больше принцесс\n2) Нет, с меня хватит, я устал";
        private const string loss = "ВЫ ПРОИГРАЛИ \nЖелаете ли вы еще раз попробовать спасти принцессу?\n1) Да, я должен ее спасти\n2) Нет, думаю, придет другой принц и спасет её";

        private string[,] traps;
        private bool isStart = true;
        private bool isContinue = true;

        Prince prince;

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
            Random random = new Random();

            for (int i = 0; i <= 9; i++)
            {
                traps[random.Next(1, 11), random.Next(1, 11)] = "*";
            }
        }

        public void PrintField()
        {
            for (int row = 1; row <= numberOfRows; row++)
            {
                Console.WriteLine(separatorOfRows);

                for (int column = 1; column <= numberOfSlashes; column++)
                {
                    Console.Write("| ");

                    if (column == prince.XPrince && row == prince.YPrince)
                    {
                        Console.Write("X ");
                    }
                    else if (row == 10 && column == 10)
                    {
                        Console.Write("P ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine(separatorOfRows);
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
            Random random = new Random();

            if (traps[prince.XPrince, prince.YPrince] == "*")
            {
                prince.HP -= random.Next(1, 11);
            }
        }

        public void FinishGame()
        {
            bool conditionEndGame = false;

            if (prince.HP <= 0)
            {
                Console.Clear();
                Console.WriteLine(loss);
                conditionEndGame = true;
            }

            if (prince.XPrince == 10 && prince.YPrince == 10)
            {
                Console.Clear();
                Console.WriteLine(win);
                conditionEndGame = true;
            }

            if (conditionEndGame)
            {
                int endChoice = 0;
                bool isParsed = false;

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
                        Console.WriteLine(finalText);
                        break;
                }
            }
        }
    }
}

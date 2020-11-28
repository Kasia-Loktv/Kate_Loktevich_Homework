using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    class Game
    {
        public void GetTraps(ref string[,] trap)
        {           
            Random random = new Random();
            for (int i = 0; i <= 9; i++)
            {
                trap[random.Next(1, 11), random.Next(1, 11)] = "*";
            }
        }
        

        public void PrintField(ref Prince prince)
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int k = 1; k < 8; k++)
                {
                    Console.Write("------");
                }
                Console.WriteLine();
                for (int j = 1; j <= 11; j++)
                {
                    Console.Write("| ");
                    if (j == prince.valueXPrince && i == prince.valueYPrince)
                    {
                        Console.Write("X ");
                    }
                    else if (i == 10 && j == 10)
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
            for (int k = 1; k < 8; k++)
            {
                Console.Write("------");
            }
        }

        public void MovePrince(ref Prince prince)
        {
            Console.WriteLine("\nПользуйтесь клавишами w, a, s, d для управления \nw - вверх \ns - вниз \na - влево \nd - вправо");
            Console.Write("Ваш выбор: ");
            string direction = Console.ReadLine();
            switch (direction)
            {
                case "w":
                    if (prince.valueYPrince == 1)
                    {
                        break;
                    }
                    prince.valueYPrince -= 1;
                    break;
                case "s":
                    if (prince.valueYPrince == 10)
                    {
                        break;
                    }
                    prince.valueYPrince += 1;
                    break;
                case "a":
                    if (prince.valueXPrince == 1)
                    {
                        break;
                    }
                    prince.valueXPrince -= 1;
                    break;
                case "d":
                    if (prince.valueXPrince == 10)
                    {
                        break;
                    }
                    prince.valueXPrince += 1;
                    break;
            }

            Console.SetCursorPosition(0, 0);
        }
        public void FallIntoTrap(ref Prince prince, ref string[,] tr)
        {
            Random random = new Random();
            if (tr[prince.valueXPrince, prince.valueYPrince] == "*")
            {

                prince.HP -= random.Next(1, 11);
            }
        }
        public void FinishGame(ref Prince prince, ref bool starting, ref bool continuation)
        {
            bool condition = false;
            if (prince.HP <= 0)
            {
                Console.Clear();
                Console.WriteLine(" ВЫ ПРОИГРАЛИ \nЖелаете ли вы еще раз попробовать спасти принцессу?\n1) Да, я должен ее спасти\n" +
                    "2) Нет, думаю, придет другой принц и спасет её");
                condition = true;
            }
            
            if (prince.valueXPrince == 10 && prince.valueYPrince == 10)
            {
                Console.Clear();
                Console.WriteLine("  ВЫ ПОБЕДИЛИ!!!  Принцесса спасена \nЖелаете ли вы спасти еще одну принцессу?\n1) Да, нужно спасти больше принцесс\n" +
                    "2) Нет, с меня хватит, я устал");
                condition = true;
            }

            if (condition)
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

                if (endChoice == 1)
                {
                    continuation = false;
                    Console.Clear();
                }
                if (endChoice == 2)
                {
                    continuation = false;
                    starting = false;
                    Console.Clear();
                    Console.WriteLine("Возвращайся скорее, ещё много принцесс ждут, когда ты их спасешь");
                }
            }
        }
    }
}

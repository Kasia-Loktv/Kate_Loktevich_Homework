using System;
using static System.String;

namespace Bomb
{
    public static class ConsoleInput
    {
        private static string name;

        private static int menuItem;
        private static int number;

        public static string InputName()
        {
            name = Console.ReadLine();

            while (IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(Resources.ErrorOfConsoleInput);
                name = Console.ReadLine();
            }
            return name;
        }

        public static int InputMenuItem()
        {
            while (!int.TryParse(Console.ReadLine(), out menuItem) || !Array.Exists((int[])Enum.GetValues(typeof(MenuItem)), item => item == menuItem))
            {
                Console.WriteLine(Resources.ErrorOfConsoleInput);
            }
            return menuItem;
        }

        public static int InputNumber()
        {
            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.WriteLine(Resources.ErrorOfConsoleInput);
            }
            return number;
        }
    }
}

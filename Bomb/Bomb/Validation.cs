using System;
using static System.String;

namespace Bomb
{
    public static class Validation
    {
        private static string inputData;

        private static int inputMenuItem;

        public static string ValidateInput()
        {
            inputData = Console.ReadLine();

            while (IsNullOrWhiteSpace(inputData))
            {
                Console.WriteLine(Resources.ErrorOfValidation);
                inputData = Console.ReadLine();
            }
            return inputData;
        }

        public static int ValidateInputMenuItem()
        {
            while (!int.TryParse(Console.ReadLine(), out inputMenuItem) || !Array.Exists((int[])Enum.GetValues(typeof(MenuItem)), item => item == inputMenuItem))
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
            return inputMenuItem;
        }

        public static void ValidateInput(out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || input < 0)
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
        }
    }
}

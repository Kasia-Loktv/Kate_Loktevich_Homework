using System;
using static System.String;

namespace Bomb
{
    public static class Validation
    {
        private static string inputName;

        private static int inputMenuItem;
        private static int inputData;

        public static string ValidateInputName()
        {
            inputName = Console.ReadLine();

            while (IsNullOrWhiteSpace(inputName))
            {
                Console.WriteLine(Resources.ErrorOfValidation);
                inputName = Console.ReadLine();
            }
            return inputName;
        }

        public static int ValidateInputMenuItem()
        {
            while (!int.TryParse(Console.ReadLine(), out inputMenuItem) || !Array.Exists((int[])Enum.GetValues(typeof(MenuItem)), item => item == inputMenuItem))
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
            return inputMenuItem;
        }

        public static int ValidateInput()
        {
            while (!int.TryParse(Console.ReadLine(), out inputData) || inputData < 0)
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
            return inputData;
        }
    }
}

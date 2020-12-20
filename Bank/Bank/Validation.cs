using System;

namespace Bank
{
    public class Validation
    {
        public static void ValidateInput()
        {
            while (String.IsNullOrWhiteSpace(Console.ReadLine()))
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
        }

        public static void ValidateInput(int lengthOfAccount)
        {
            while (Console.ReadLine().Length != lengthOfAccount)
            {
                Console.WriteLine(Resources.TextOfAccountLength);
            }
        }

        public static void ValidateInput(out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || input < 0)
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
        }

        public static void ValidateInput(int accountCounter, out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || input > accountCounter)
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
        }

        public static void ValidateInput(int debitCard, int creditCard, out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || (input != debitCard && input != creditCard))
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
        }

        public static void ValidateStartInput(int menuItem, out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || input != menuItem)
            {
                Console.WriteLine(Resources.ErrorOfValidation);
            }
        }
    }
}

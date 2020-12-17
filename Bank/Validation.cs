using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Validation
    {
        public static void ValidateInput(out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input))
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

        public static void ValidateInput(int lengthOfAccount, out string input)
        {
            input = Console.ReadLine();
            while (input.Length != lengthOfAccount)
            {
                Console.WriteLine(Resources.TextOfAccountLength);
                input = Console.ReadLine();
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

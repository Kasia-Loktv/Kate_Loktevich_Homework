using System;
using System.Collections.Generic;

namespace Bank
{
    public abstract class Account
    {
        private const int NameLength = 20;

        public const string AccountWord = " cчет ";
        public const string BalanceWord = " Баланс: ";

        public string Name { get; private set; }
        public int Balance { get; private set; }

        public List<Card> Cards { get; set; }
       
        private Random random;

        public Account()
        {
            Name = SetName();
            Balance = 0;
            Cards = new List<Card>();
        }

        private string SetName()
        {
            random = new Random();
            for (int i = 0; i < NameLength; i++)
            {
                Name += random.Next(1, 10).ToString();
            }
            return Name;
        }

        public void IncreaseBalance(int cash)
        {
            Balance += cash;
        }

        public void ReduceBalance(int cash)
        {
            Balance -= cash;
        }

        public abstract string GetAccountInformation();
    }
}

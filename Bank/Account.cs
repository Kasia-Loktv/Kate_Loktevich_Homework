using System;
using System.Collections.Generic;

namespace Bank
{
    public class Account
    {
        private const int NameLength = 20;

        private const string AccountWord = "Счет ";
        private const string BalanceWord = " Баланс: ";

        public int Balance { get; private set; }
        public bool IsContainCreditCard { get; set; }
        public bool IsWithoutCards { get; set; }

        public List<Card> Cards { get; set; }

        private string name;
        private string generatedName;

        private Random random;

        public Account()
        {
            name = SetName();
            Balance = 0;
            Cards = new List<Card>();
            IsContainCreditCard = false;
            IsWithoutCards = true;
        }

        private string SetName()
        {
            random = new Random();
            for (int i = 0; i < NameLength; i++)
            {
                generatedName += random.Next(1, 10).ToString();
            }
            return generatedName;
        }

        public string GetAccountInformation()
        {
            return AccountWord + name + BalanceWord + Balance;
        }

        public void IncreaseBalance(int cash)
        {
            Balance += cash;
        }

        public void ReduceBalance(int cash)
        {
            Balance -= cash;
        }
    }
}

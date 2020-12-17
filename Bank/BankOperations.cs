using System;
using System.Collections.Generic;

namespace Bank
{
    public class BankOperations
    {
        private string message;
        private string recipientName;
        private string recipientAccount;

        private int accountNumber;
        private int accountNumberForTransfer;
        private int money;
        private int menuChoice;
        private int cardChoice;

        private List<Account> accounts;

        public void StartBank()
        {
            accounts = new List<Account>();

            Console.Write(Resources.TextOfFirstMenu + Resources.TextOfChoice);
            Validation.ValidateStartInput((int)MenuItem.CreateAccount, out menuChoice);

            CreateAccount();   

            while (true)
            {
                accountNumber = 0;
                ShowAccountsAndCards();
                Console.WriteLine(Resources.TextOfMenu);

                if (message != null)
                {
                    Console.WriteLine(Resources.ErrorMessage, message);
                    message = null;
                }

                Console.WriteLine(Resources.TextOfChoice);
                Validation.ValidateInput(out menuChoice);

                switch (menuChoice)
                {
                    case (int)MenuItem.CreateAccount:
                        CreateAccount();
                        break;

                    case (int)MenuItem.CreateCard:
                        CreateCard();
                        break;

                    case (int)MenuItem.PutMoney:
                        PutMoney();
                        break;

                    case (int)MenuItem.WithdrawMoney:
                        WithdrawMoney();
                        break;

                    case (int)MenuItem.TransferMoneyInside:
                        TransferMoneyInside();
                        break;

                    case (int)MenuItem.TransferMoneyOutside:
                        TransferMoneyOutside();
                        break;
                }

                ShowAccountsAndCards();
            }
        }

        public void ShowAccountsAndCards()
        {
            Console.Clear();
            accountNumber = 1;

            foreach (Account account in accounts)
            {
                Console.WriteLine(Resources.ListItem, accountNumber.ToString(), account.GetAccountInformation());
                accountNumber++;

                foreach (var card in account.Cards)
                {
                    Console.WriteLine(card.GetCardInformation());
                }

                Console.WriteLine();
            }
        }

        public void CreateAccount()
        {
            Console.WriteLine(Resources.TextOfCards);
            Validation.ValidateInput((int)AccountItem.DebitAccount, (int)AccountItem.CreditAccount, out cardChoice);

            switch (cardChoice)
            {
                case (int)AccountItem.DebitAccount:
                    accounts.Add(new DebitAccount());                    
                    break;

                case (int)AccountItem.CreditAccount:
                    accounts.Add(new CreditAccount());                 
                    break;
            }
        }

        public void CreateCard()
        {
            Console.WriteLine(Resources.TextOfAccount);
            Validation.ValidateInput(accounts.Count, out accountNumber);

            accounts[accountNumber - 1].Cards.Add(new Card());                       
        }

        public void PutMoney()
        {
            Console.WriteLine(Resources.TextOfAccount);
            Validation.ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(Resources.TextOfSum);
            Validation.ValidateInput(out money);

            accounts[accountNumber - 1].IncreaseBalance(money);
        }

        public void WithdrawMoney()
        {
            Console.WriteLine(Resources.TextOfAccount);
            Validation.ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(Resources.TextOfSum);
            Validation.ValidateInput(out money);

            if (accounts[accountNumber - 1] is DebitAccount && accounts[accountNumber - 1].Balance < money)
            {
                message = Resources.NotEnoughMoney;
            }
            else if (accounts[accountNumber - 1].Balance < 0)
            {
                message = Resources.ExistenceOfCredit;
            }
            else
            {
                accounts[accountNumber - 1].ReduceBalance(money);
            }
        }

        public void TransferMoneyInside()
        {
            Console.WriteLine(Resources.TextOfAccount);
            Validation.ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(Resources.TextOfAccountForTransfer);
            Validation.ValidateInput(accounts.Count, out accountNumberForTransfer);

            Console.WriteLine(Resources.TextOfSum);
            Validation.ValidateInput(out money);

            if (accounts[accountNumber - 1] is DebitAccount && accounts[accountNumber - 1].Balance < money)
            {
                message = Resources.NotEnoughMoney;
            }
            else if (accounts[accountNumber - 1] is CreditAccount && accounts[accountNumberForTransfer - 1] is DebitAccount)
            {
                message = Resources.ErrorOfTransfer;
            }
            else if (accounts[accountNumber - 1].Balance < 0)
            {
                message = Resources.ExistenceOfCredit;
            }
            else
            {
                accounts[accountNumber - 1].ReduceBalance(money);
                accounts[accountNumberForTransfer - 1].IncreaseBalance(money);
            }
        }

        public void TransferMoneyOutside()
        {
            Console.WriteLine(Resources.TextOfAccount);
            Validation.ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(Resources.TextOfRecipient);
            recipientName = Console.ReadLine();

            Console.WriteLine(Resources.TextOfAccountForTransfer + Resources.TextOfAccountLength);
            Validation.ValidateInput(Resources.AccountLength, out recipientAccount);            

            Console.WriteLine(Resources.TextOfSum);
            Validation.ValidateInput(out money);

            if (accounts[accountNumber - 1] is DebitAccount && accounts[accountNumber - 1].Balance < money)
            {
                message = Resources.NotEnoughMoney;
            }
            else if (accounts[accountNumber - 1].Balance < 0)
            {
                message = Resources.ExistenceOfCredit;
            }
            else
            {
                accounts[accountNumber - 1].ReduceBalance(money);
            }
        }
    }
}

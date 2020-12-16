using System;
using System.Collections.Generic;

namespace Bank
{
    public class BankOperations
    {
        private const string TextOfMenu = "Выберите операцию:\n1. Создать счёт \n2. Создать карту \n" +
            "3. Положить деньги на счёт \n4. Снять деньги со счёта \n5. Перевести средства с одного счёта на другой \n" +
            "6. Перевести средства на счёт другого пользователя банка\n";
        private const string TextOfFirstMenu = "У Вас пока нет счетов \nВыберите операцию:\n1. Создать счёт \n";
        private const string TextOfCards = "Выберите тип карты: 1-дебетовая, 2-кредитная";
        private const string TextOfChoice = "Ваш выбор: ";
        private const string TextOfAccount = "Выберите счет";
        private const string TextOfSum = "Введите сумму";
        private const string ListItem = "{0}. {1}";
        private const string ExistenceOfCredit = "На счете есть кредит. Сначала погасите его!";
        private const string TextOfAccountForTransfer = "На какой счёт перевести деньги? ";
        private const string TextOfRecipient = "Введите ФИО получателя: ";
        private const string TextOfAccountLength = "Введите 20 символов: ";
        private const string ErrorMessage = "ОШИБКА: {0}\n";
        private const string ErrorOfCreditCard = "Это кредитный счет. На него можно завести только кредитную карту";
        private const string ErrorOfDebitCard = "Это дебетовый счет. На него можно завести только дебетовую карту";
        private const string ErrorOfValidation = "Неправильный ввод. Введите ещё раз";
        private const string ErrorOfTransfer = "Операция запрещена. Запрещены переводы с кредитной карты на дебетовую";
        private const string NotEnoughMoney = "Недостаточно средств!";

        private const int AccountLength = 20;

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
            Console.Write(TextOfFirstMenu + TextOfChoice);

            while (!int.TryParse(Console.ReadLine(), out menuChoice) || menuChoice != (int)MenuItem.CreateAccount)
            {
                Console.WriteLine(ErrorOfValidation);
            }

            accounts.Add(new Account());

            while (true)
            {
                accountNumber = 0;
                ShowAccountsAndCards();
                Console.WriteLine(TextOfMenu);

                if (message != null)
                {
                    Console.WriteLine(ErrorMessage, message);
                    message = null;
                }

                Console.WriteLine(TextOfChoice);
                ValidateInput(out menuChoice);

                switch (menuChoice)
                {
                    case (int)MenuItem.CreateAccount:
                        accounts.Add(new Account());
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
                Console.WriteLine(ListItem, accountNumber.ToString(), account.GetAccountInformation());
                accountNumber++;

                foreach (var card in account.Cards)
                {
                    Console.WriteLine(card.GetCardInformation());
                }

                Console.WriteLine();
            }
        }

        public void CreateCard()
        {
            Console.WriteLine(TextOfAccount);
            ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(TextOfCards);
            ValidateInput((int)CardItem.DebitCard, (int)CardItem.CreditCard, out cardChoice);

            switch (cardChoice)
            {
                case (int)CardItem.DebitCard:
                    if (accounts[accountNumber - 1].IsContainCreditCard)
                    {
                        message = ErrorOfCreditCard;
                    }
                    else
                    {
                        accounts[accountNumber - 1].Cards.Add(new DebitCard());
                        accounts[accountNumber - 1].IsWithoutCards = false;
                    }
                    break;

                case (int)MenuItem.CreateCard:
                    if (!accounts[accountNumber - 1].IsContainCreditCard && !accounts[accountNumber - 1].IsWithoutCards)
                    {
                        message = ErrorOfDebitCard;
                    }
                    else
                    {
                        accounts[accountNumber - 1].Cards.Add(new CreditCard());
                        accounts[accountNumber - 1].IsWithoutCards = false;
                        accounts[accountNumber - 1].IsContainCreditCard = true;
                    }
                    break;
            }
        }

        public void PutMoney()
        {
            Console.WriteLine(TextOfAccount);
            ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(TextOfSum);
            ValidateInput(out money);

            accounts[accountNumber - 1].IncreaseBalance(money);
        }

        public void WithdrawMoney()
        {
            Console.WriteLine(TextOfAccount);
            ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(TextOfSum);
            ValidateInput(out money);

            if (!accounts[accountNumber - 1].IsContainCreditCard && accounts[accountNumber - 1].Balance < money)
            {
                message = NotEnoughMoney;
            }
            else if (accounts[accountNumber - 1].Balance < 0)
            {
                message = ExistenceOfCredit;
            }
            else
            {
                accounts[accountNumber - 1].ReduceBalance(money);
            }
        }

        public void TransferMoneyInside()
        {
            Console.WriteLine(TextOfAccount);
            ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(TextOfAccountForTransfer);
            ValidateInput(accounts.Count, out accountNumberForTransfer);

            Console.WriteLine(TextOfSum);
            ValidateInput(out money);

            if (!accounts[accountNumber - 1].IsContainCreditCard && accounts[accountNumber - 1].Balance < money)
            {
                message = NotEnoughMoney;
            }
            else if (accounts[accountNumber - 1].IsContainCreditCard && !accounts[accountNumberForTransfer - 1].IsContainCreditCard)
            {
                message = ErrorOfTransfer;
            }
            else if (accounts[accountNumber - 1].Balance < 0)
            {
                message = ExistenceOfCredit;
            }
            else
            {
                accounts[accountNumber - 1].ReduceBalance(money);
                accounts[accountNumberForTransfer - 1].IncreaseBalance(money);
            }
        }

        public void TransferMoneyOutside()
        {
            Console.WriteLine(TextOfAccount);
            ValidateInput(accounts.Count, out accountNumber);

            Console.WriteLine(TextOfRecipient);
            recipientName = Console.ReadLine();

            Console.WriteLine(TextOfAccountForTransfer + TextOfAccountLength);
            recipientAccount = Console.ReadLine();

            while (recipientAccount.Length != AccountLength)
            {
                Console.WriteLine(TextOfAccountLength);
                recipientAccount = Console.ReadLine();
            }

            Console.WriteLine(TextOfSum);
            ValidateInput(out money);

            if (!accounts[accountNumber - 1].IsContainCreditCard && accounts[accountNumber - 1].Balance < money)
            {
                message = NotEnoughMoney;
            }
            else if (accounts[accountNumber - 1].Balance < 0)
            {
                message = ExistenceOfCredit;
            }
            else
            {
                accounts[accountNumber - 1].ReduceBalance(money);
            }
        }

        public void ValidateInput(out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine(ErrorOfValidation);
            }
        }

        public void ValidateInput(int accountCounter, out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || input > accountCounter)
            {
                Console.WriteLine(ErrorOfValidation);
            }
        }

        public void ValidateInput(int debitCard, int creditCard, out int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || (input != debitCard && input != creditCard))
            {
                Console.WriteLine(ErrorOfValidation);
            }
        }
    }
}

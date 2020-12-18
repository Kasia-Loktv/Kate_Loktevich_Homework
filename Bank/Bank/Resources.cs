namespace Bank
{
    public class Resources
    {
        public const string TextOfMenu = "Выберите операцию:\n1. Создать счёт \n2. Создать карту \n" +
            "3. Положить деньги на счёт \n4. Снять деньги со счёта \n5. Перевести средства с одного счёта на другой \n" +
            "6. Перевести средства на счёт другого пользователя банка\n";
        public const string TextOfFirstMenu = "У Вас пока нет счетов \nВыберите операцию:\n1. Создать счёт \n";
        public const string TextOfCards = "Выберите тип счёта: 1-дебетовый, 2-кредитный";
        public const string TextOfChoice = "Ваш выбор: ";
        public const string TextOfAccount = "Выберите счет";
        public const string TextOfSum = "Введите сумму";
        public const string ListItem = "{0}. {1}";
        public const string ExistenceOfCredit = "На счете есть кредит. Сначала погасите его!";
        public const string TextOfAccountForTransfer = "На какой счёт перевести деньги? ";
        public const string TextOfRecipient = "Введите ФИО получателя: ";
        public const string TextOfAccountLength = "Введите 20 символов: ";
        public const string ErrorMessage = "ОШИБКА: {0}\n";
        public const string ErrorOfValidation = "Неправильный ввод. Введите ещё раз";
        public const string ErrorOfTransfer = "Операция запрещена. Запрещены переводы с кредитного счёта на дебетовый";
        public const string NotEnoughMoney = "Недостаточно средств!";

        public const int AccountLength = 20;
    }
}

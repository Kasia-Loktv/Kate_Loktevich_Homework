namespace Bank
{
    public class CreditAccount : Account
    {
        private const string CreditWord = "Кредитный";

        public override string GetAccountInformation()
        {
            return CreditWord + AccountWord + Name + BalanceWord + Balance;
        }
    }
}

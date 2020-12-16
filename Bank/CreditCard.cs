namespace Bank
{
    public class CreditCard : Card
    {
        private const string CreditType = "   Кредитная Карта ";

        public override string GetCardInformation()
        {
            return CreditType + NumberCard;
        }
    }
}

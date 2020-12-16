namespace Bank
{
    public class DebitCard : Card
    {
        private const string DebitType = "   Дебетовая Карта ";

        public override string GetCardInformation()
        {
            return DebitType + NumberCard;
        }
    }
}

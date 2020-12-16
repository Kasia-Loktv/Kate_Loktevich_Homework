using System;

namespace Bank
{
    public abstract class Card
    {
        private const int NumberLength = 16;

        public string NumberCard { get; set; }

        private string generatedNumber;

        private Random random;

        public Card()
        {
            NumberCard = SetName();
        }

        private string SetName()
        {
            random = new Random();
            for (int i = 0; i < NumberLength; i++)
            {
                generatedNumber += random.Next(1, 10).ToString();
            }
            return generatedNumber;
        }

        public abstract string GetCardInformation();
    }
}

﻿using System;

namespace Bank
{
    public class Card
    {
        private const int NumberLength = 16;
        private const string CardWord = "Карта № ";

        private string numberCard;
        private string generatedNumber;

        private Random random;

        public Card()
        {
            numberCard = SetName();
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

        public string GetCardInformation()
        {
            return CardWord + numberCard;
        }
    }
}

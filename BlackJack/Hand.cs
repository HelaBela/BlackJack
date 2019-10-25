using System.Collections.Generic;

namespace BlackJack
{
    public class Hand
    {
        public readonly List<CardNumber> cardsAtHand;

        public Hand()
        { 
            cardsAtHand = new List<CardNumber>();
        }

        public int CalculateScore()
        {
            var score = 0;
            foreach (var cardNumber in cardsAtHand)
            {
                if (cardNumber == CardNumber.Ace)
                {
                    score += 11;
                }
                else if (cardNumber == CardNumber.Jack || cardNumber == CardNumber.Queen ||
                         cardNumber == CardNumber.King)
                {
                    score += 10;
                }
                else
                {
                    score += (int) cardNumber;
                }
            }

            return score;
        }
    }
}
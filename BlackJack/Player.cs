using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public List<CardNumber> cardsNumbersAtHand { get; set; }
        public int Total;
        public IConsoleOperations _consoleOperations;


        public Player(IConsoleOperations consoleOperations)
        {
            _consoleOperations = consoleOperations;
            cardsNumbersAtHand = new List<CardNumber>();
            
        }


        public int CalculateScore(List<CardNumber> cardNumbersAtHand)
        {
            var total = 0;

            foreach (var cardNumber in cardNumbersAtHand)
            {
                if (cardNumber == CardNumber.Ace)
                {
                    _consoleOperations.Write("should Ace be a 1 or 11 ?");
                    total += Int32.Parse(_consoleOperations.Read());
                }
                else if (cardNumber == CardNumber.Jack || cardNumber == CardNumber.Queen ||
                         cardNumber == CardNumber.King)
                {
                    total += 10;
                }
                else
                {
                    total += cardNumber.GetHashCode();
                }
            }

            return total;
        }

        public bool HitOrStay()
        {
            if (_consoleOperations.Read() != "0" || _consoleOperations.Read() != "1")
            {
                _consoleOperations.Write("choose a correct answer");
            }

            if (_consoleOperations.Read() == "1")
            {
                return true;
            }

            else
            {
                _consoleOperations.Write($"your final score is {Total} . Now Dealer plays.");

                return false;
            }
        }
    }
}
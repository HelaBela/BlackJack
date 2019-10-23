using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
      
        public IConsoleOperations _consoleOperations;
        public int Total { get; private set; }


        public Player(IConsoleOperations consoleOperations)
        {
            _consoleOperations = consoleOperations;

        }

        public void Play(List<CardNumber> cardsAtHand)
        {
            _consoleOperations.Write($"your score is {Total} Hit = 1, Stay = 0");
            
            
            
        }
        
        
        public void CalculateTotalScore(List<CardNumber> cardsAtHand)
        {
            foreach (var cardNumber in cardsAtHand)
            {
                if (cardNumber == CardNumber.Ace)
                {
                    _consoleOperations.Write("should Ace be a 1 or 11 ?");
                    Total += Int32.Parse(_consoleOperations.Read());
                }
                else if (cardNumber == CardNumber.Jack || cardNumber == CardNumber.Queen ||
                         cardNumber == CardNumber.King)
                {
                    Total += 10;
                }
                else
                {
                    Total += cardNumber.GetHashCode();
                }
            }
        }


    }
}
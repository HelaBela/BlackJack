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

        public string Play(List<CardNumber> cardsAtHand)
        {
            CalculateTotalScore(cardsAtHand);
            _consoleOperations.Write($"your score is {Total} Hit = 1, Stay = 0");
            var answer = HitOrStay();

            if (answer == "stay")
            {
                _consoleOperations.Write($"your final score is {Total}. Now the dealer plays");
                return "Done";
            }

            if (answer == "wrong")
            {
                _consoleOperations.Write("Wrong answer. choose '1' for hit or '0' to stay");
            }

            return "Play";
        }


        public string HitOrStay()
        {
            if (_consoleOperations.Read() == "1") return "hit";
            if (_consoleOperations.Read() == "0") return "stay";
            else return "wrong";
        }


        private void CalculateTotalScore(List<CardNumber> cardsAtHand)
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
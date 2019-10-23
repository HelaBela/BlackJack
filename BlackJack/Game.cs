using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Game
    {
        private Deck _deck;

        private Player _player;

        private IConsoleOperations _consoleOperations;
        private List<CardNumber> _cardsNumbersAtHand;
        private int Total;

        public Game(Player player, IConsoleOperations consoleOperations, Deck deck)
        {
            _deck = deck;
            _player = player;
            _consoleOperations = consoleOperations;
            _cardsNumbersAtHand = new List<CardNumber>();
        }

        public void Start()
        {
            ShowTwoCards();
            _player.Play(_cardsNumbersAtHand);
            
            
           
            
            
            
            
            
            _consoleOperations.Write($"your score is {Total} Hit = 1, Stay = 0");

            while (_consoleOperations.Read() == "1")
            {
                var nextCard = _deck.TakeCard();
                _cardsNumbersAtHand.Add(nextCard.CardNumber);
                _consoleOperations.Write(nextCard.CardNumber + " " + nextCard.Suit);

                _consoleOperations.Write($"your score is {Total} Hit = 1, Stay = 0");
            }

            if (_consoleOperations.Read() == "0")
            {
                _consoleOperations.Write($"your final score is {Total}. Now the dealer plays");
            }
        }

        public void ShowTwoCards()
        {
            var twoCards = _deck.TakeTwoCards();

            foreach (var card in twoCards)
            {
                _consoleOperations.Write(card.CardNumber + " " + card.Suit);
                _cardsNumbersAtHand.Add(card.CardNumber);
            }
        }
        
        
        
        
        
        
        
        

        
        
        
        
        
        
        

//        public string HitOrStay()
//        {
//            while (_consoleOperations.Read() != "1" || _consoleOperations.Read() != "0")
//            {
//                if (_consoleOperations.Read() == "1")
//                {
//                    return "hit";
//                }
//
//                if (_consoleOperations.Read() == "0")
//                {
//                    return "stay";
//                }
//            }
//
//            return "again";
//        }


        public void boo()
        {
            if (Total == 21)
            {
                _consoleOperations.Write("The player won!");
            }

            if (Total > 21)
            {
                _consoleOperations.Write("It is a burst. The Dealer won!");
            }

            if (Total < 21)
            {
                _deck = new Deck();
            }
        }
    }
}
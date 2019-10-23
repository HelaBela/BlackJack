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
        private List<CardNumber> _cardNumbersAtHand;
       

        public Game(Player player, IConsoleOperations consoleOperations, Deck deck)
        {
            _deck = deck;
            _player = player;
            _consoleOperations = consoleOperations;
            _cardNumbersAtHand = new List<CardNumber>();
        }

        public void Start()
        {
            ShowTwoCards();
           var playerMove = _player.Play(_cardNumbersAtHand);

           while (playerMove == "Play")
           {
               var nextCard = _deck.TakeCard();
               _cardNumbersAtHand.Add(nextCard.CardNumber);
               _consoleOperations.Write(nextCard.CardNumber + " " + nextCard.Suit);
               playerMove = _player.Play(_cardNumbersAtHand);
           }

           if (playerMove == "Done")
           {
               
           }
        }

        public void ShowTwoCards()
        {
            var twoCards = _deck.TakeTwoCards();

            foreach (var card in twoCards)
            {
                _consoleOperations.Write(card.CardNumber + " " + card.Suit);
                _cardNumbersAtHand.Add(card.CardNumber);
            }
        }
        
        
        

//        public void boo()
//        {
//            if (Total == 21)
//            {
//                _consoleOperations.Write("The player won!");
//            }
//
//            if (Total > 21)
//            {
//                _consoleOperations.Write("It is a burst. The Dealer won!");
//            }
//
//            if (Total < 21)
//            {
//                _deck = new Deck();
//            }
//        }
    }
}
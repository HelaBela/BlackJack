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
        private int Total;

        public Game(Player player, IConsoleOperations consoleOperations, Deck deck)
        {
            _deck = deck;
            _player = player;
            _consoleOperations = consoleOperations;
        }

        public void Play()
        {
            var twoCards = _deck.TakeTwoCards();
            
            foreach (var card in twoCards)
            {
                _consoleOperations.Write(card.CardNumber + " " + card.Suit);
                _player.cardsNumbersAtHand.Add(card.CardNumber);
            }

            _consoleOperations.Write($"your score is {_player.Total} Hit = 1, Stay = 0");

             while (_player.HitOrStay())
            {
                var nextCard = _deck.TakeCard();
                _player.cardsNumbersAtHand.Add(nextCard.CardNumber);
                _consoleOperations.Write(nextCard.CardNumber + " " + nextCard.Suit);

            }
        }

     

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
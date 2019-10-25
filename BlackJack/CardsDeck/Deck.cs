using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        private readonly IRandomChooser _randomChooser;

        public Deck()
        {
            Reset();
            _randomChooser = new RandomChooser();
        }

        public void Reset()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                    .Select(c => new Card()
                        {
                            Suit = (Suit) s,
                            CardNumber = (CardNumber) c
                        }
                    )
                )
                .ToList();
        }


        public Card TakeOneCard()
        {
            var random = _randomChooser.RandomNumber(0, Cards.Count);
            
            var card = Cards[random];
            Cards.Remove(card);

            return card;
        }
        
        //take one card can be called twice

        public List<Card> TakeTwoCards()
        {
            var random =  _randomChooser.RandomNumber(0, Cards.Count);
            var random2 =  _randomChooser.RandomNumber(0, Cards.Count);
            var takenCards = new List<Card>() {Cards[random], Cards[random2]};

            Cards.RemoveAll(takenCards.Contains);

            return takenCards;
        }
    }
}
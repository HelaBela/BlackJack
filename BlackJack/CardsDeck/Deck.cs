using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Reset();
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
            var random = new Random().Next(0, 52);
            var card = Cards[random];
            Cards.Remove(card);

            return card;
        }

        public List<Card> TakeTwoCards()
        {
            var random = new Random().Next(0, 52);
            var random2 = new Random().Next(0, 52);
            var takenCards = new List<Card>() {Cards[random], Cards[random2]};

            Cards.RemoveAll(takenCards.Contains);

            return takenCards;
        }
    }
}
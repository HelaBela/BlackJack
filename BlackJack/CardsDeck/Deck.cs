using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        private readonly IRandomChooser _randomChooser;

        public Deck(IRandomChooser randomChooser)
        {
            _randomChooser = randomChooser;
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
            var random = _randomChooser.RandomNumber(0, Cards.Count);
            Console.WriteLine($"AAAAAAAAA {random}");
            var card = Cards[random];
            Cards.Remove(card);

            return card;
        }
    }
}
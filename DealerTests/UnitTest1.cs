using BlackJack;
using NUnit.Framework;

namespace DealerTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ThereAre52CardsInDeck()
        {
            var deck = new Deck();
            var game = new Game(new Player(), new ConsoleOperations(), deck);

            Assert.AreEqual(52, deck.Cards.Count);

        }
    }
}
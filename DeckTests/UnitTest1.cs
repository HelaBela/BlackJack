using BlackJack;
using NUnit.Framework;

namespace DeckTests
{
    public class DeckTests
    {
        [SetUp]
        public void Setup()
        {
        }

       
       [Test]
        public void BeforeGameStartDeckHas52Cards()
        {
            //arrange
            IRandomChooser randomChooser = new RandomChooser();
            Deck deck = new Deck(randomChooser);

            //act

            var amountOfCards = deck.Cards.Count;

            //assert
            Assert.AreEqual(52, amountOfCards);
        }

       [Test]
        public void AfterDealingACard_DeckHasOneCardLess()
        {
            //arrange
            IRandomChooser randomChooser = new RandomChooser();
            Deck deck = new Deck(randomChooser);
            deck.TakeOneCard();

            //act

            var amountOfCards = deck.Cards.Count;

            //assert
            Assert.AreEqual(51, amountOfCards);
        }
    }
}
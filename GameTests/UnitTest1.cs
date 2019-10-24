using BlackJack;
using Moq;
using NUnit.Framework;

namespace GameTests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AfterHumanChoosesHitNextCardIsAddedToHisCardsAtHand()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var playerHuman = new PlayerHuman(consoleOperations.Object);
            var playerComputer = new PlayerComputer(consoleOperations.Object);
            consoleOperations.Setup(s => s.Read()).Returns("1");
            var game = new Game(consoleOperations.Object, playerHuman, playerComputer);

            //act
            game.Start();
            var amountOfCardsAtHand = game.humanCardsAtHand.Count;
            
            //assert
            Assert.AreEqual(3,amountOfCardsAtHand);
        }
        
        [Test]
        public void BeforeGameStartDeckHas52Cards()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var playerHuman = new PlayerHuman(consoleOperations.Object);
            var playerComputer = new PlayerComputer(consoleOperations.Object);
            var game = new Game(consoleOperations.Object, playerHuman, playerComputer);

            //act
            
            var amountOfCards= game._deck.Cards.Count;
            
            //assert
            Assert.AreEqual(52,amountOfCards);
        }
        
        [Test]
        public void AtGameStartDeckHas50Cards()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var playerHuman = new PlayerHuman(consoleOperations.Object);
            var playerComputer = new PlayerComputer(consoleOperations.Object);
            var game = new Game(consoleOperations.Object, playerHuman, playerComputer);

            //act
            game.Start();
            var amountOfCards= game._deck.Cards.Count;
            
            //assert
            Assert.AreEqual(50,amountOfCards);
        }
    }
}
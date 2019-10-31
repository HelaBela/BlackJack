using System.Collections.Generic;
using System.Linq;
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
        public void AfterHumanChoosesHit_NextCardIsAddedToHisCardsAtHand()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var playerHuman = new PlayerHuman(consoleOperations.Object, "d");
            consoleOperations.Setup(s => s.Read()).Returns("1");
            var humanPlayers = new List<IPlayer>() {playerHuman};
            var randomChooser = new Mock<IRandomChooser>();
            randomChooser.SetupSequence(s => s.RandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(10)
                .Returns(12)
                .Returns(13);
            
            var game = new Game(consoleOperations.Object, humanPlayers, randomChooser.Object);
            



            //act
            game.Start();


            var score = game.GetScoreFor(playerHuman);
            
            //assert
            
            Assert.AreEqual(24, score); //why its zero?
        }

        [Test]
         public void WhenHumanPlayersGoesOver21_ItsABust()
         {
             //arrange
             var consoleOperations = new Mock<IConsoleOperations>();
             var playerHuman = new PlayerHuman(consoleOperations.Object, "d");
             var playerHumanList = new List<IPlayer>(){playerHuman};
             var randomChooser = new Mock<IRandomChooser>();
             randomChooser.SetupSequence(s => s.RandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                 .Returns(10)
                 .Returns(12)
                 .Returns(13);
             
             var game = new Game(consoleOperations.Object, playerHumanList, randomChooser.Object);
             consoleOperations.Setup(s => s.Read()).Returns("1");

             //act
             game.Start();
             
             
             //assert
             consoleOperations.Verify(
                 m => m.Write(It.Is<string>(c => c == "It's a bust!")));
         }
         
         [Test]
         public void WhenHumanPlayersGoesOver21_DealerWins()
         {
             //arrange
             var consoleOperations = new Mock<IConsoleOperations>();
             var playerHuman = new PlayerHuman(consoleOperations.Object, "d");
             var playerHumanList = new List<IPlayer>(){playerHuman};
             var randomChooser = new Mock<IRandomChooser>();
             randomChooser.SetupSequence(s => s.RandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                 .Returns(10)
                 .Returns(12)
                 .Returns(13);
             var game = new Game(consoleOperations.Object, playerHumanList, randomChooser.Object);
             consoleOperations.Setup(s => s.Read()).Returns("1");

             //act
             game.Start();
             
             
             //assert
             consoleOperations.Verify(
                 m => m.Write(It.Is<string>(c => c == "Dealer wins!")));
         }
         
         
           
         [Test]
         public void WinnerHasTheHighestScore()
         {
             //arrange
             var consoleOperations = new Mock<IConsoleOperations>();
             var playerHuman = new PlayerHuman(consoleOperations.Object, "1");
             var playerHuman2 = new PlayerHuman(consoleOperations.Object, "2");
             var playerComputer = new PlayerComputer(consoleOperations.Object);
             var playerHumanList = new List<IPlayer>(){playerHuman, playerHuman2};
             
             var mockRandomChooser = new Mock<IRandomChooser>();
             mockRandomChooser.SetupSequence(s => s.RandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                 .Returns(10).Returns(12).Returns(13);

             consoleOperations.SetupSequence(s => s.Read()).Returns("1").Returns("0").Returns("0");

             var game = new Game(consoleOperations.Object, playerHumanList, mockRandomChooser.Object);


             //act
             game.Start();
             
             
             //assert
           //Assert.Contains(); how to test that?
           consoleOperations.Verify(
               m => m.Write(It.Is<string>(c => c == "Dealer wins !")));
         }
         
            
         [Test]
         public void WhenPlayersHaveSameScore_ItsATie()
         {
             //arrange
          
 
             //act
         
             
             //assert
           
         }
         
    }
}
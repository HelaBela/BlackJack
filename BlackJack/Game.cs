using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Game
    {
        private readonly Deck _deck;
        private readonly IConsoleOperations _consoleOperations;

        private readonly PlayerHand _computer;
        private readonly PlayerHand _human;

        //private List<PlayerHand> _players;

        public Game(IConsoleOperations consoleOperations, IPlayer humanPlayer, IPlayer computerPlayer)
        {
            _deck = new Deck();
            _consoleOperations = consoleOperations;

            // _players = new List<PlayerHand>();
            // _players.Add(new PlayerHand(human, new Hand()));
            //_players.Add(new PlayerHand(computer, new Hand()));


            _human = new PlayerHand(humanPlayer, new Hand());
            _computer = new PlayerHand(computerPlayer, new Hand());
        }

        public void Start()
        {
            var humanChoice = PlayerChoice(_human, true);


            while (humanChoice == "hit")
            {
                humanChoice = PlayerChoice(_human, false);

                if (humanChoice == "burst")
                {
                    break;
                }
            }

            if (humanChoice == "stay")
            {
                var computerChoice = PlayerChoice(_computer, true);


                while (computerChoice == "hit")
                {
                    computerChoice = PlayerChoice(_computer, false);
                }
            }

            FindPlayerWithHighestScore();
        }

        private string PlayerChoice(PlayerHand playerHand, bool firstRound)
        {
            //refactor this method
            if (firstRound)
            {
                var firstCard = _deck.TakeOneCard();
                var secondCard = _deck.TakeOneCard();

                _consoleOperations.Write(
                    $"{firstCard.CardNumber} {firstCard.Suit} {secondCard.CardNumber} {secondCard.Suit}");

                playerHand.Hand.cardsAtHand.Add(firstCard.CardNumber);
                playerHand.Hand.cardsAtHand.Add(secondCard.CardNumber);
            }
            else
            {
                var nextCard = _deck.TakeOneCard();
                _consoleOperations.Write(nextCard.CardNumber + " " + nextCard.Suit);
                playerHand.Hand.cardsAtHand.Add(nextCard.CardNumber);
            }

            var score = playerHand.Hand.CalculateScore();

            if (score < 21)
            {
                var playerChoice = playerHand.Player.HitOrStay(score);
                return playerChoice;
            }

            if (score == 21)
            {
                return "stay";
            }

            _consoleOperations.Write($"You are at burst. Your score is {score}");

            return "burst";
        }

        private void FindPlayerWithHighestScore()
        {
            var humanScore = _human.Hand.CalculateScore();
            var computerScore = _computer.Hand.CalculateScore();
            
            if (humanScore > computerScore || computerScore > 21)
            {
                _consoleOperations.Write($"You won! Woooohooooo ohhh yeah {_human.Player.Name}");
            }

            if (humanScore < computerScore && computerScore <= 21 || humanScore > 21)
            {
                _consoleOperations.Write($"{_computer.Player.Name} wins! ");
            }
        }
    }
}
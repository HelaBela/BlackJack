using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Game
    {
        private readonly Deck _deck;
        private readonly IConsoleOperations _consoleOperations;
        private readonly PlayerHand _human;

        private readonly PlayerHand _computer;
        private List<PlayerHand> _humanPlayers;

        public Game(IConsoleOperations consoleOperations, IPlayer humanPlayer, IPlayer humanPlayer2,
            IPlayer computerPlayer)
        {
            _deck = new Deck();
            _consoleOperations = consoleOperations;

            _humanPlayers = new List<PlayerHand>();
            _humanPlayers.Add(new PlayerHand(humanPlayer, new Hand()));
            _humanPlayers.Add(new PlayerHand(humanPlayer2, new Hand()));


            _computer = new PlayerHand(computerPlayer, new Hand());
            _human = new PlayerHand(humanPlayer, new Hand());
        }

        public void Start()
        {
            PlayUntilBustOrStay(_human);

            if (IsThereABust(_human) == false)
            {
                PlayUntilBustOrStay(_computer);
            }

            FindTheWinner();
        }

        private void PlayUntilBustOrStay(PlayerHand playerHand)
        {
            SetUpInitialCards(playerHand);
            var playerChoice = playerHand.Player.HitOrStay(playerHand.Hand.CalculateScore());

            while (playerChoice == "hit" && IsThereABust(playerHand) == false)
            {
                Play(playerHand);

                if (IsThereABust(playerHand))
                {
                    _consoleOperations.Write($"{playerHand.Player.Name} lost.");
                    _consoleOperations.Write("It's a bust!");
                    break;
                }

                playerChoice = playerHand.Player.HitOrStay(playerHand.Hand.CalculateScore());
            }
        }

        private void SetUpInitialCards(PlayerHand playerHand)
        {
            var firstCard = _deck.TakeOneCard();
            var secondCard = _deck.TakeOneCard();

            _consoleOperations.Write(
                $"{firstCard.CardNumber} {firstCard.Suit} {secondCard.CardNumber} {secondCard.Suit}");

            playerHand.Hand.cardsAtHand.Add(firstCard.CardNumber);
            playerHand.Hand.cardsAtHand.Add(secondCard.CardNumber);
        }

        private void Play(PlayerHand playerHand)
        {
            var nextCard = _deck.TakeOneCard();
            _consoleOperations.Write(nextCard.CardNumber + " " + nextCard.Suit);
            playerHand.Hand.cardsAtHand.Add(nextCard.CardNumber);
        }


        private void FindTheWinner()
        {
            var humanScore = _human.Hand.CalculateScore();
            var computerScore = _computer.Hand.CalculateScore();

            if (humanScore > computerScore && computerScore > 0 || computerScore > 21)
            {
                _consoleOperations.Write($"You won! Woooohooooo ohhh yeah {_human.Player.Name}");
            }

            if (humanScore < computerScore && computerScore <= 21)
            {
                _consoleOperations.Write($"{_computer.Player.Name} wins! ");
            }
        }

        private bool IsThereABust(PlayerHand playerHand)
        {
            var score = playerHand.Hand.CalculateScore();

            if (score > 21)
            {
                return true;
            }

            return false;
        }
    }
}
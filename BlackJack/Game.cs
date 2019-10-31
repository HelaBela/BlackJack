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
        private readonly List<PlayerHand> _humanPlayers;

        public Game(IConsoleOperations consoleOperations, List<IPlayer> humanPlayers, IRandomChooser randomChooser)
        {
            _deck = new Deck(randomChooser);
            _consoleOperations = consoleOperations;
            _computer = new PlayerHand(new PlayerComputer((consoleOperations)));
            _humanPlayers = humanPlayers.Select(s => new PlayerHand(s)).ToList();
        }

        public void Start()
        {
            PlayUntilBustOrStay(_humanPlayers);

            var noHumanPlayerBusted = _humanPlayers.Any(player => !IsThereABust(player));
            if (noHumanPlayerBusted)
            {
                PlayUntilBustOrStay(_computer);
            }

            FindTheWinner();
        }

        public int GetScoreFor(PlayerHuman player)
        {
            var playerHand = _humanPlayers.FirstOrDefault(pl => pl.GetName() == player.Name);
            return playerHand.GetScore();
        }

        private void PlayUntilBustOrStay(List<PlayerHand> playerHands)
        {
            foreach (var playerHand in playerHands)
            {
                PlayUntilBustOrStay(playerHand);
            }
        }

        private void PlayUntilBustOrStay(PlayerHand playerHand)
        {
            DealInitialCards(playerHand);
            var playerChoice = playerHand.ChooseHitOrStay();

            while (CanContinuePlay(playerHand, playerChoice))
            {
                ContinuePlay(playerHand);

                if (IsThereABust(playerHand))
                {
                    playerHand.Communicate($"{playerHand.GetName()} lost.");
                    playerHand.Communicate("It's a bust!");
                    break;
                }

                playerChoice = playerHand.ChooseHitOrStay();
            }
        }

        private bool CanContinuePlay(PlayerHand playerHand, string playerChoice)
        {
            return playerChoice == "hit" && !IsThereABust(playerHand);
        }

        private void DealInitialCards(PlayerHand playerHand)
        {
            var firstCard = _deck.TakeOneCard();
            var secondCard = _deck.TakeOneCard();

            playerHand.DealCard(firstCard);
            playerHand.DealCard(secondCard);
        }

        private void ContinuePlay(PlayerHand playerHand)
        {
            var nextCard = _deck.TakeOneCard();
            playerHand.DealCard(nextCard);
        }


        private void FindTheWinner()
        {
            var humanPlayers = _humanPlayers.Where(player => player.GetScore() < 22)
                .OrderByDescending(player => player.GetScore());
            var highestScoringHuman = humanPlayers.FirstOrDefault();
            var computerScore = _computer.GetScore();


            if (highestScoringHuman != null && (highestScoringHuman.GetScore() > computerScore && computerScore > 0 ||
                                                computerScore > 21))
            {
                highestScoringHuman.Communicate($"You won! Woooohooooo ohhh yeah {highestScoringHuman.GetName()}");
            }

            if (highestScoringHuman != null && (highestScoringHuman.GetScore() < computerScore && computerScore <= 21) || _humanPlayers.All(player => player.GetScore() > 22) )
            {
                _computer.Communicate($"{_computer.GetName()} wins!");
            }
        }

        private bool IsThereABust(PlayerHand playerHand)
        {
            return playerHand.IsScoreGreaterThan(21);
        }
    }
}
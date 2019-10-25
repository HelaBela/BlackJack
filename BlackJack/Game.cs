using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Game
    {
        public Deck _deck;
        private IConsoleOperations _consoleOperations;
        
        //List<PlayerHand> -> coz player ISet< associated with playerhand>
        private IPlayer Human;
        private IPlayer Human2;
        private IPlayer Computer;
        private int humanScore;
        private int computerScore;
        public List<CardNumber> humanCardsAtHand;
        public List<CardNumber> human2CardsAtHand;
        private List<CardNumber> computerCardsAtHand;
        private bool IsHumanPlaying;


        public Game(IConsoleOperations consoleOperations, IPlayer human, IPlayer computer)
        {
            _deck = new Deck();
            _consoleOperations = consoleOperations;
            Computer = computer;
            Human = human;
            humanCardsAtHand = new List<CardNumber>();
            computerCardsAtHand = new List<CardNumber>();
        }

        public void Start()
        {
            IsHumanPlaying = true;
            ShowTwoCards();

            humanScore = CalculateScore(humanCardsAtHand);

            Human.Play(humanScore);

            var humanChoice = Human.HitOrStay(humanScore, computerScore);

            while (humanChoice != "stay" && humanChoice != "wrong" && !DidHumanBurstOrWin())
            {
                var nextCard = _deck.TakeOneCard();
                _consoleOperations.Write(nextCard.CardNumber + " " + nextCard.Suit);

                humanCardsAtHand.Add(nextCard.CardNumber);
                humanScore = CalculateScore(humanCardsAtHand);
                if (DidHumanBurstOrWin())
                {
                    break;
                }
                Human.Play(humanScore);
                humanChoice = Human.HitOrStay(humanScore, computerScore);
            }

            if (humanChoice == "stay" && !DidHumanBurstOrWin())
            {
                IsHumanPlaying = false;
                ShowTwoCards();
                computerScore = CalculateScore(computerCardsAtHand);
                Computer.Play(computerScore);
                var computerChoice = Computer.HitOrStay(humanScore, computerScore);

                while (computerChoice == "hit")
                {
                    var nextCard = _deck.TakeOneCard();
                    _consoleOperations.Write(nextCard.CardNumber + " " + nextCard.Suit);

                    computerCardsAtHand.Add(nextCard.CardNumber);
                    computerScore = CalculateScore(computerCardsAtHand);
                    Computer.Play(computerScore);
                    computerChoice = Computer.HitOrStay(humanScore, computerScore);
                }
            }

            else if (humanChoice == "wrong")
            {
                _consoleOperations.Write("Wrong choice. Hit = 1, Stay = 0");
            }
        }

        private void ShowTwoCards()
        {
            var twoCards = _deck.TakeTwoCards();

            foreach (var card in twoCards)
            {
                _consoleOperations.Write(card.CardNumber + " " + card.Suit);

                if (!IsHumanPlaying)
                {
                    computerCardsAtHand.Add(card.CardNumber);
                }

                humanCardsAtHand.Add(card.CardNumber);
            }
        }

        private int CalculateScore(List<CardNumber> cardsAtHand)
        {
            var score = 0;
            foreach (var cardNumber in cardsAtHand)
            {
                if (cardNumber == CardNumber.Ace)
                {
                    score += 11;
                }
                else if (cardNumber == CardNumber.Jack || cardNumber == CardNumber.Queen ||
                         cardNumber == CardNumber.King)
                {
                    score += 10;
                }
                else
                {
                    score += (int) cardNumber;
                }
            }

            return score;
        }

        private bool DidHumanBurstOrWin()
        {
            if (humanScore > computerScore && humanScore<21 && !IsHumanPlaying)
            {
                _consoleOperations.Write("You won! Woooohooooo ohhh yeah ");
                return true;
            }
            

            if (humanScore > 21)
            {
                _consoleOperations.Write($"You are currently at burst. Your score is {humanScore}");
                _consoleOperations.Write("Dealer wins! ");
                return true;
            }
            return false;

        }
    }
}
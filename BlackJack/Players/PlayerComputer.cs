using System.Collections.Generic;

namespace BlackJack
{
    public class PlayerComputer : IPlayer
    {
        public IConsoleOperations _consoleOperations;

        public PlayerComputer(IConsoleOperations consoleOperations)
        {
            _consoleOperations = consoleOperations;
        }

        public void Play(int score)
        {
            _consoleOperations.Write($"your score is {score} Hit = 1, Stay = 0");
        }

        public string HitOrStay(int humanScore, int computerScore)
        {
            if (humanScore > computerScore)
            {
                _consoleOperations.Write("1");
                return "hit";
            }

            if (humanScore < computerScore && computerScore<21)
            {
                _consoleOperations.Write("Dealer wins!");
                return "dealerWins";
            }

            if (humanScore == computerScore)
            {
                _consoleOperations.Write("It's a tie.");
                return "stay";
            }
            if (computerScore == 21 && computerScore != humanScore)
            {
                _consoleOperations.Write("Dealer wins!");
                return "dealerWins";
            }

            _consoleOperations.Write("Dealer is at burst ");
            return "nothing";
            

        }
    }
}
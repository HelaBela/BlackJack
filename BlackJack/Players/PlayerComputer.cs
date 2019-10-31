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

        public string Name => "Dealer";

        public string ChooseHitOrStay(int score)
        {
            _consoleOperations.Write($"your score is {score} Hit = 1, Stay = 0");

            if (score < 18)
            {
                return "hit";
            }

            return "stay";
        }

        public void Communicate(string content)
        {
            _consoleOperations.Write(content);
        }
    }
}
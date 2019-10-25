using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class PlayerHuman : IPlayer
    {
        public IConsoleOperations _consoleOperations;

        public PlayerHuman(IConsoleOperations consoleOperations)
        {
            _consoleOperations = consoleOperations;
        }

        public string Name => "Alex";

        public string HitOrStay(int score)
        {
            _consoleOperations.Write($"your score is {score} Hit = 1, Stay = 0");
            
            while (true)
            {
                var answer = _consoleOperations.Read();
                if (answer == "1") return "hit";
                if (answer == "0") return "stay";
                _consoleOperations.Write("Wrong choice. Hit = 1, Stay = 0");
            }
        }
    }
}
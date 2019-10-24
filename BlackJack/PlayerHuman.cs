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

        public void Play(int score)
        {
            _consoleOperations.Write($"your score is {score} Hit = 1, Stay = 0");
        }


        public string HitOrStay(int score, int computerScore)
        {
            if (_consoleOperations.Read() == "1") return "hit";
            if (_consoleOperations.Read() == "0") return "stay";
            else return "wrong";
        }
        
    }
}
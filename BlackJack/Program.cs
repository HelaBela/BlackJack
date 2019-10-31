using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleOperations = new ConsoleOperations();
            var playerHuman = new PlayerHuman(consoleOperations, "Tony");
            var playerHuman2 = new PlayerHuman(consoleOperations, "Helena");
            var playerList = new List<IPlayer>() {playerHuman, playerHuman2};
            var playerComputer = new PlayerComputer(consoleOperations);
            
            var game = new Game(consoleOperations, playerList, new RandomChooser());

            game.Start();
        }
    }
}
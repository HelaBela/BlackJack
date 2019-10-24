using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            var consoleOperations = new ConsoleOperations();
            var playerHuman = new PlayerHuman(consoleOperations);
            var playerComputer = new PlayerComputer(consoleOperations);
            
            
            var game = new Game(consoleOperations, playerHuman, playerComputer);

         game.Start();
         

        }
    }
}
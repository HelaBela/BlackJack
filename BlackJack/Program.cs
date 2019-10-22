using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            var consoleOperations = new ConsoleOperations();
            var player = new Player(consoleOperations);
            var deck = new Deck();
            //var card = new Card();
            var cardNumbersAtHand = new List<CardNumber>();
            
            var game = new Game(player, consoleOperations, deck);

         game.Play();
           
       


//            var playerHand = game.Play();
//       
//            foreach (var VARIABLE in playerHand)
//            {
//                Console.Write(VARIABLE);
//            }

        }
    }
}
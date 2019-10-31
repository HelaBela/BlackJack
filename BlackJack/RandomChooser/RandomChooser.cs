using System;

namespace BlackJack
{
    public class RandomChooser : IRandomChooser
    {
        public int RandomNumber(int min, int max)
        {
            Console.WriteLine("In Real RandomChooser");
            var number = new Random().Next(0, max);

            return number;
        }
    }
}
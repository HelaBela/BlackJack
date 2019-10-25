using System;

namespace BlackJack
{
    public class RandomChooser : IRandomChooser
    {
        public int RandomNumber(int min, int max)
        {
            var number = new Random().Next(0, max);

            return number;
        }
    }
}
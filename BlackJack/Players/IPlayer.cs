using System.Collections.Generic;

namespace BlackJack
{
    public interface IPlayer
    {
        string Name { get; }
        string HitOrStay(int score);
    }
}
using System.Collections.Generic;

namespace BlackJack
{
    public interface IPlayer
    {
        string Name { get; }
        string ChooseHitOrStay(int score);

        void Communicate(string content);
    }
}
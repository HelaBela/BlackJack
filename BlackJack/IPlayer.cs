using System.Collections.Generic;

namespace BlackJack
{
    public interface IPlayer
    {
        void Play(int score);

        string HitOrStay(int humanScore, int computerScore);
       
        

    }
}
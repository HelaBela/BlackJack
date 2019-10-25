namespace BlackJack
{
    public class PlayerHand
    {
        public Hand Hand;
        public IPlayer Player;

        public PlayerHand(IPlayer player, Hand hand)
        {
            Player = player;
            Hand = hand;
        }
    }
}
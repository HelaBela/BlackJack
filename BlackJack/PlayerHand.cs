namespace BlackJack
{
    public class PlayerHand
    {
        private Hand _hand;
        private IPlayer _player;

        public PlayerHand(IPlayer player, Hand hand)
        {
            _player = player;
            _hand = hand;
        }
    }
}
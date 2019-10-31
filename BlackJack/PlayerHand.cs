using System.Collections.Generic;

namespace BlackJack
{
    public class PlayerHand
    {
        private readonly IPlayer _player;
        private List<CardNumber> _cardsAtHand;

        public PlayerHand(IPlayer player)
        {
            _player = player;
            _cardsAtHand = new List<CardNumber>();
        }

        public string ChooseHitOrStay()
        {
            return _player.ChooseHitOrStay(GetScore());
        }

        public void DealCard(Card card)
        {

            _cardsAtHand.Add(card.CardNumber);
            _player.Communicate(card.CardNumber + " " + card.Suit);;
        }

        public bool IsScoreGreaterThan(int score)
        {
            return GetScore() > 21;
        }

        public void Communicate(string content)
        {
            _player.Communicate(content);
        }

        public int GetScore()
        {
            var score = 0;
            var ace = 1;
            

            foreach (var cardNumber in _cardsAtHand)
            {
                if (cardNumber == CardNumber.Ace)
                {
                    score += 11;
                }
                else if (cardNumber == CardNumber.Jack || cardNumber == CardNumber.Queen ||
                         cardNumber == CardNumber.King)
                {
                    score += 10;
                }
                else
                {
                    score += (int) cardNumber;
                }
            }

            return score;
        }

        public string GetName()
        {
            return _player.Name;
        }
    }
}
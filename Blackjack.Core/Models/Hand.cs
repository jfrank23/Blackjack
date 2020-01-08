using System.Collections.Generic;

namespace Blackjack.Core
{
    public class Hand
    {
        public List<Card> Cards;
        public int Bet;
        public int Score;
        public bool Busted;

        public Hand(int Bet)
        {
            this.Bet = Bet;
            Score = 0;
            Busted = false;
            Cards = new List<Card>();
        }

        public void AddCardToHand(Card newCard)
        {
            Cards.Add(newCard);
            Score += CalculateChangeInScore(newCard);
            Busted = IsBust(Score);
        }

        private int CalculateChangeInScore(Card newCard) //Need To Recalculate whole hand after each turn
        {
            if ((int)newCard.CardValue > 10) //Ten or Face
            {
                return 10;
            }
            else if ((int)newCard.CardValue == 1) //Ace
            {
                if (IsBust(Score + 11))
                {
                    return 1;
                }
                else
                {
                    return 11;
                }
            }
            else
            {
                return (int)newCard.CardValue; //Regular Card
            }
        }

        public bool IsBust(int Score)
        {
            if (Score > 21)
            {
                return true;
            }
            return false;
        }
    }
}

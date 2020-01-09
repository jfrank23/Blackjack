using System.Collections.Generic;
using System.Linq;

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
            Score = CalculateChangeInScore(Cards);
            Busted = IsBust(Score);
        }

        private int CalculateChangeInScore(IEnumerable<Card> Cards) //Need To Recalculate whole hand after each turn
        {
            var score = 0;
            foreach(var newCard in Cards.OrderByDescending(C => C.CardValue))
            {
                if ((int)newCard.CardValue > 10) //Ten or Face
                {
                    score+= 10;
                }
                else if ((int)newCard.CardValue == 1) //Ace
                {
                    if (IsBust(score + 11))
                    {
                        score += 1;
                    }
                    else
                    {
                        score += 11;
                    }
                }
                else
                {
                    score += (int)newCard.CardValue; //Regular Card
                }
            }
            return score;
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

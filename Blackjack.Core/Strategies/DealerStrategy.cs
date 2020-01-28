﻿using Blackjack.Core.Actions;
using System.Linq;

namespace Blackjack.Core.Strategies
{
    public interface Strategy
    {
        IPlayAction ExecuteStrategy(Hand currentHand, Shoe shoe);
        IBetAction BettingStrategy();
    }
    public class DealerStrategy : Strategy
    {
        public IBetAction BettingStrategy()
        {
            return new NoBet();
        }

        public IPlayAction ExecuteStrategy(Hand currentHand, Shoe shoe)
        {
            if(currentHand.Score == 17 && currentHand.Cards.Any(c => c.CardValue == CardValue.Ace))
            {
                return new Hit();
            }
            if (currentHand.Score < 17)
            {
                return new Hit();
            }
            else
            {
                return new Stand();
            }
        }
    }
}

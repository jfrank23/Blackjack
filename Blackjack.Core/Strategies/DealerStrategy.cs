using Blackjack.Core.Actions;
using System;
using System.Collections.Generic;
using System.Text;

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
    public class ManualStrategy : Strategy
    {
        public IBetAction BettingStrategy()
        {
            throw new NotImplementedException();
        }

        public IPlayAction ExecuteStrategy(Hand currentHand, Shoe shoe)
        {
            throw new NotImplementedException();
        }
    }
}

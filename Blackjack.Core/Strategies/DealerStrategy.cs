using Blackjack.Core.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Core.Strategies
{
    public interface Strategy
    {
        bool ExecuteStrategy(Hand currentHand, Shoe shoe);
    }
    public class DealerStrategy : Strategy
    {
        public ActionMapper actionMapper = new ActionMapper();
        public bool ExecuteStrategy(Hand currentHand, Shoe shoe)
        {
            if (currentHand.Score < 17)
            {
                actionMapper.Map("Hit");
                return false;
            }
            else
            {
                actionMapper.Map("Stand");
                return true;
            }
        }
    }
    public class ManualStrategy : Strategy
    {
        public bool ExecuteStrategy(Hand currentHand, Shoe shoe)
        {
            throw new NotImplementedException();
        }
    }
}

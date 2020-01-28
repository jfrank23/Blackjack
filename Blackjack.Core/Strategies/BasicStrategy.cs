using Blackjack.Core.Actions;

namespace Blackjack.Core.Strategies
{
    public class BasicStrategy : IStrategy
    {
        public IBetAction BettingStrategy()
        {
            return new MinBet();
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
}

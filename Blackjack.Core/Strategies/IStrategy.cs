using Blackjack.Core.Actions;

namespace Blackjack.Core.Strategies
{
    public interface IStrategy
    {
        IPlayAction ExecuteStrategy(Hand currentHand, Shoe shoe);
        IBetAction BettingStrategy();
    }
}

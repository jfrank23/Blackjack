using Blackjack.Core.Actions;
using Blackjack.Core.UserInteraction;

namespace Blackjack.Core.Strategies
{
    public class ManualStrategy : IStrategy
    {
        IInputFromPlayer inputFromPlayer;
        public ManualStrategy(IInputFromPlayer inputFromPlayer)
        {
            this.inputFromPlayer = inputFromPlayer;
        }
        public IBetAction BettingStrategy()
        {
            return inputFromPlayer.GetBet();
        }

        public IPlayAction ExecuteStrategy(Hand currentHand, Shoe shoe)
        {
            return inputFromPlayer.GetPlayAction();
        }
    }
}

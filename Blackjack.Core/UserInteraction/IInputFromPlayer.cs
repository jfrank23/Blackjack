using Blackjack.Core.Actions;

namespace Blackjack.Core.UserInteraction
{
    public interface IInputFromPlayer
    {
        IBetAction GetBet();
        IPlayAction GetPlayAction();
    }
}
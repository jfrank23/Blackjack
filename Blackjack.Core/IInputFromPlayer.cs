using Blackjack.Core.Actions;

namespace Blackjack.Core
{
    public interface IInputFromPlayer
    {
        IBetAction GetBet();
        IPlayAction GetPlayAction();
    }
}
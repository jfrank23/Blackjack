namespace Blackjack.Core.Actions
{
    public interface IPlayAction
    {
        bool Play(Shoe currentShoe, Hand currentHand);
    }
    public class Hit : IPlayAction
    {
        public bool Play(Shoe currentShoe, Hand currentHand)
        {
            currentHand.AddCardToHand(currentShoe.DealCard());
            return false;
        }
    }
    public class Stand : IPlayAction
    {
        public bool Play(Shoe currentShoe, Hand currentHand)
        {
            return true;
        }
    }
}

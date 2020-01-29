using System.Collections.Generic;

namespace Blackjack.Core.Actions
{
    public interface IPlayAction
    {
        bool Play(Shoe currentShoe, Hand currentHand, List<Hand> hands);
    }
    public class Hit : IPlayAction
    {
        public bool Play(Shoe currentShoe, Hand currentHand, List<Hand> hands)
        {
            currentHand.AddCardToHand(currentShoe.DealCard());
            return false;
        }
    }
    public class Stand : IPlayAction
    {
        public bool Play(Shoe currentShoe, Hand currentHand, List<Hand> hands)
        {
            return true;
        }
    }
    public class Double : IPlayAction
    {
        public bool Play(Shoe currentShoe, Hand currentHand, List<Hand> hands)
        {
            currentHand.AddCardToHand(currentShoe.DealCard());
            currentHand.Bet *= 2;
            return true;
        }
    }

    public class Split : IPlayAction
    {
        public bool Play(Shoe currentShoe, Hand currentHand, List<Hand> hands)
        {
            var splitOffCard = currentHand.Cards[0];

            var newHand = new Hand();
            newHand.AddCardToHand(splitOffCard);
            newHand.AddCardToHand(currentShoe.DealCard());
            newHand.Bet = currentHand.Bet;
            hands.Add(newHand);

            currentHand.Cards.Remove(splitOffCard);
            currentHand.AddCardToHand(currentShoe.DealCard());
            return false;
        }
    }
}

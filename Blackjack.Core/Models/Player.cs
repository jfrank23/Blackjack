using Blackjack.Core.Strategies;

namespace Blackjack.Core
{
    public class Player
    {
        public string name { get; set; }
        public Hand primaryHand;
        public int Money;
        public Strategy strategy;

        public Player(Strategy strategy,int startingMoney = 100)
        {
            this.strategy = strategy;
            name = strategy.ToString();
            Money = startingMoney;
            primaryHand = new Hand();
        }
        public int PlayTurn(Shoe currentShoe)
        {
            var done = false;
            while (done == false)
            {
                var action = strategy.ExecuteStrategy(primaryHand, currentShoe);
                done = action.Play(currentShoe,primaryHand);
                if (primaryHand.Busted)
                {
                    done = true;
                }
            }
            return primaryHand.Score;
        }
        public int PlaceBet()
        {
            var bettingAction = strategy.BettingStrategy();
            return bettingAction.Bet();
        }

    }
}

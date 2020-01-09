using Blackjack.Core.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Core
{
    public class Player
    {
        public Hand primaryHand;
        public int Money;
        public Strategy strategy;

        public Player(Strategy strategy,int startingMoney = 100)
        {
            this.strategy = strategy;
            Money = startingMoney;
            primaryHand = new Hand(0);
        }
        public int Play(Shoe currentShoe)
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
        public int Bet()
        {
            var bettingAction = strategy.BettingStrategy();
            return bettingAction.Bet();
        }

    }
}

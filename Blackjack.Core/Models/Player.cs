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
        public void Play(Shoe currentShoe)
        {
            var done = false;
            while (done == false)
            {
                done = strategy.ExecuteStrategy(primaryHand, currentShoe);
            }
        }

    }
}

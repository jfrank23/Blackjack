using Blackjack.Core.Strategies;
using System.Collections.Generic;

namespace Blackjack.Core
{
    public class PlayerStats
    {
        public PlayerStats()
        {
            NonBlackJackWins = 0;
            Loss = 0;
            BlackJackWins = 0;
            Push = 0;
        }
        public int NonBlackJackWins { get; set; }
        public int Loss { get; set; }
        public int BlackJackWins { get; set; }
        public int Push { get; set; }
    }
    public class Player
    {
        public string name { get; set; }
        public List<Hand> hands;
        public int Money;
        public IStrategy strategy;
        public PlayerStats stats = new PlayerStats();
        public Player(IStrategy strategy,int startingMoney = 100)
        {
            this.strategy = strategy;
            name = strategy.ToString();
            Money = startingMoney;
        }
        public List<int> PlayTurn(Shoe currentShoe)
        {
            var Scores = new List<int>();
            for(int i =0; i<hands.Count; i++)
            {
                var currentHand = hands[i];
                var done = false;
                while (done == false)
                {
                    var action = strategy.ExecuteStrategy(currentHand, currentShoe);
                    done = action.Play(currentShoe, currentHand, hands);
                    if (currentHand.Busted)
                    {
                        done = true;
                    }
                }
                Scores.Add(currentHand.Score);
            }
            
            return Scores;
        }
        public int PlaceBet()
        {
            var bettingAction = strategy.BettingStrategy();
            return bettingAction.Bet();
        }

    }
}

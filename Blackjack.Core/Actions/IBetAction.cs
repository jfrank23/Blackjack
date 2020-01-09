using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Core.Actions
{
    public interface IBetAction
    {
        int Bet();
    }
    public class MinBet : IBetAction
    {
        public int Bet()
        {
            return 5;
        }
    }
    public class MaxBet : IBetAction
    {
        public int Bet()
        {
            return 100;
        }
    }
    public class NoBet : IBetAction
    {
        public int Bet()
        {
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Core.Actions
{
    public class ActionMapper
    {
        public IPlayAction Map(string move)
        {
            switch (move)
            {
                case "Hit":
                    return new Hit();
                case "Stand":
                    return new Stand();
                default:
                    return new Stand();
            }
        }
    }
}

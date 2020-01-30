using Blackjack.Core;
using Blackjack.Core.Actions;
using Blackjack.Core.UserInteraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackCLI.InputFromPlayer
{
    class InputFromPlayerCLI : IInputFromPlayer
    {
        public IBetAction GetBet()
        {
            return new NoBet();
        }

        public IPlayAction GetPlayAction()
        {
            var done = false;
            while (done == false)
            {
                Console.WriteLine("Please select your action: [H]it, [S]tand");
                var response = Console.ReadLine();
                if (response.ToLower().StartsWith("h"))
                {
                    return new Hit();
                }
                else if (response.ToLower().StartsWith("s"))
                {
                    return new Stand();
                }
                else
                {
                    return new Stand();
                }
            }
            throw new NotImplementedException();
            
        }
    }
}

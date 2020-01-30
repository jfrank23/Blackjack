using Blackjack.Core;
using Blackjack.Core.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Blackjack.Input
{
    public class InputFromPlayerWPF : IInputFromPlayer
    {
        public IBetAction GetBet()
        {
            return new NoBet();
        }

        public IPlayAction GetPlayAction()
        {
            MessageBoxResult result = MessageBox.Show("Would you like to hit?", "Play", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    return new Hit();
                case MessageBoxResult.No:
                    return new Stand();
            }
            throw new NotImplementedException();
        }
    }
}

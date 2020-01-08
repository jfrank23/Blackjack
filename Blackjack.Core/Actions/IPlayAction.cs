using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Core.Actions
{
    public interface IPlayAction
    {
        void Play();
    }
    public class Hit : IPlayAction
    {
        public void Play()
        {
            throw new NotImplementedException();
        }
    }
    public class Stand : IPlayAction
    {
        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}

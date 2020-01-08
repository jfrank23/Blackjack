using Blackjack.Core.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Core.Game
{
    public class Game
    {
        private Shoe currentShoe;
        public Player dealer;
        public Player player;
        public IEnumerable<Player> players;

        public Game(int decks = 5)
        {
            currentShoe = new Shoe(decks);
            dealer = new Player(new DealerStrategy());
            player = new Player(new ManualStrategy());
            players = new List<Player> { player, dealer };
        }
        public void StartGame()
        {
            while(dealer.primaryHand.Cards.Count < 2)
            {
                foreach(var person in players)
                {
                    person.primaryHand.AddCardToHand(currentShoe.DealCard());
                }
            }
        }
        public void PlayRound()
        {
            foreach(var person in players)
            {
                person.Play(currentShoe);
            }
        }
    }
}

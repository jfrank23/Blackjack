using Blackjack.Core.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
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
            player = new Player(new DealerStrategy());
            players = new List<Player> { player};
        }
        public void StartGame()
        {
            while(dealer.primaryHand.Cards.Count < 2)
            {
                foreach(var person in players.Concat(new[] { dealer }))
                {
                    person.primaryHand.AddCardToHand(currentShoe.DealCard());
                }
            }
        }
        public void PlayRound()
        {
            PlaceInitialBets();
            IndividualsPlay();
            CalculateOutcome();
        }

        private void PlaceInitialBets()
        {
            foreach (var person in players)
            {
                person.primaryHand.Bet = person.Bet();
            }
        }

        private void IndividualsPlay()
        {
            if (dealer.primaryHand.Score != 21)
            {
                foreach (var person in players.Concat(new[] { dealer }))
                {
                    person.Play(currentShoe);
                }
            }
        }

        private void CalculateOutcome()
        {
            foreach (var person in players)
            {
                if (person.primaryHand.Busted)
                {
                    person.Money -= person.primaryHand.Bet;
                }
                else if (dealer.primaryHand.Busted)
                {
                    person.Money += person.primaryHand.Bet;
                }
                else if (person.primaryHand.Score > dealer.primaryHand.Score)
                {
                    person.Money += person.primaryHand.Bet;
                }
                else if (person.primaryHand.Score < dealer.primaryHand.Score)
                {
                    person.Money -= person.primaryHand.Bet;
                }

            }
        }
    }
}

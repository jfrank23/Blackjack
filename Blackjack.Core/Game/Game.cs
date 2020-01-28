using Blackjack.Core.Strategies;
using Blackjack.Core.UserInteraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Core.Game
{
    public class Game
    {
        private Shoe currentShoe;
        public Player dealer;
        public Player player;
        public int decks;
        public IEnumerable<Player> players;
        private readonly IDisplayGame display;

        public IInputFromPlayer InputFromPlayer { get; }

        public Game(IInputFromPlayer inputFromPlayer, IDisplayGame display, int decks = 5)
        {
            currentShoe = new Shoe(decks);
            dealer = new Player(new DealerStrategy());
            player = new Player(new BasicStrategy()) { name = "player" };
            players = new List<Player> { player };
            this.display = display;
            this.decks = decks;
        }
        public void StartHand()
        {
            while (dealer.primaryHand.Cards.Count < 2)
            {
                foreach (var person in players.Concat(new[] { dealer }))
                {
                    display.DisplayGame(this);
                    person.primaryHand.AddCardToHand(currentShoe.DealCard());
                }
            }
        }
        public void PlayRound()
        {
            PlaceInitialBets();
            IndividualsPlay();
            CalculateOutcome();
            FinishRound();
        }

        private void FinishRound()
        {
            foreach (var player in players)
            {
                player.primaryHand = new Hand();
            }
            dealer.primaryHand = new Hand();

            if (currentShoe.Cut < currentShoe.CardsDealt)
            {
                currentShoe = new Shoe(decks);
            }
        }

        private void PlaceInitialBets()
        {
            display.DisplayGame(this);
            foreach (var person in players)
            {
                person.primaryHand.Bet = person.PlaceBet();
            }
        }

        private void IndividualsPlay()
        {
            if (dealer.primaryHand.Score != 21)
            {
                foreach (var person in players)
                {
                    person.PlayTurn(currentShoe);
                    display.DisplayGame(this);
                }
                dealer.PlayTurn(currentShoe);
            }
            display.DisplayGame(this);
        }

        private void CalculateOutcome()
        {
            foreach (var person in players)
            {
                if (person.primaryHand.Busted)
                {
                    person.Money -= person.primaryHand.Bet;
                    Console.WriteLine("player loses");

                }
                else if (dealer.primaryHand.Busted)
                {
                    person.Money += person.primaryHand.Bet;
                    Console.WriteLine("player WINS");
                }
                else if (person.primaryHand.Score > dealer.primaryHand.Score)
                {
                    if(person.primaryHand.Score==21 && person.primaryHand.Cards.Count == 2)
                    {
                        person.Money += (int)Math.Floor(person.primaryHand.Bet * 1.5);
                        Console.WriteLine("player WINS - blackjack");

                    }
                    else
                    {
                        person.Money += person.primaryHand.Bet;
                        Console.WriteLine("player WINS");
                    }

                }
                else if (person.primaryHand.Score < dealer.primaryHand.Score)
                {
                    person.Money -= person.primaryHand.Bet;
                    Console.WriteLine("player loses");

                }
                else
                {
                    Console.WriteLine("Push");
                }

            }
        }
    }
}

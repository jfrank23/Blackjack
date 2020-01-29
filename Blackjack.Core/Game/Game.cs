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
            foreach(var person in players.Concat(new[] { dealer }))
            {
                person.hands = new List<Hand> { new Hand() };
            }
            while (dealer.hands[0].Cards.Count < 2)
            {
                foreach (var person in players.Concat(new[] { dealer }))
                {
                    display.DisplayGame(this);
                    person.hands[0].AddCardToHand(currentShoe.DealCard());
                }
            }
        }
        public void PlayRound()
        {
            StartHand();
            PlaceInitialBets();
            IndividualsPlay();
            CalculateOutcome();
            FinishRound();
        }

        private void FinishRound()
        {
            if (currentShoe.Cut < currentShoe.CardsDealt)
            {
                currentShoe = new Shoe(decks);
            }
        }

        private void PlaceInitialBets()
        {
            display.DisplayGame(this);
            foreach (var person in players)
                foreach (var hand in person.hands)
                    hand.Bet = person.PlaceBet();

        }

        private void IndividualsPlay()
        {
            if (dealer.hands[0].Score != 21)
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
                foreach (var playerHand in person.hands)
                {
                    if (playerHand.Busted)
                    {
                        person.Money -= playerHand.Bet;
                        person.stats.Loss += 1;
                        Console.WriteLine("player loses");
                    }
                    else if (dealer.hands[0].Busted)
                    {
                        person.Money += playerHand.Bet;
                        person.stats.NonBlackJackWins += 1;
                        Console.WriteLine("player WINS");
                    }
                    else if (playerHand.Score > dealer.hands[0].Score)
                    {
                        if (playerHand.Score == 21 && playerHand.Cards.Count == 2)
                        {
                            person.Money += (int)Math.Floor(playerHand.Bet * 1.5);
                            person.stats.BlackJackWins += 1;
                            Console.WriteLine("player WINS - blackjack");

                        }
                        else
                        {
                            person.Money += playerHand.Bet;
                            person.stats.NonBlackJackWins += 1;
                            Console.WriteLine("player WINS");
                        }

                    }
                    else if (playerHand.Score < dealer.hands[0].Score)
                    {
                        person.Money -= playerHand.Bet;
                        person.stats.Loss += 1;
                        Console.WriteLine("player loses");


                    }
                    else
                    {
                        person.stats.Push += 1;
                        Console.WriteLine("Push");
                    }
                }


            }
        }
    }
}

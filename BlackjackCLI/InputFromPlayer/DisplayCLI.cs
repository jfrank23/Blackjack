using System;
using System.Threading;
using Blackjack.Core;
using Blackjack.Core.Game;
using Blackjack.Core.UserInteraction;

namespace BlackjackCLI.InputFromPlayer
{
    class DisplayCLI : IDisplayGame
    {
        public void DisplayGame(Game game)
        {
            Console.Clear();
            ShowDealer(game.dealer);
            foreach (var player in game.players)
            {
                ShowPlayer(player);
            }
            Thread.Sleep(500);
        }
        public void ShowPlayer(Player player)
        {
            Console.WriteLine($"{player.name} : ${player.Money}");
            Console.WriteLine($"Non-BlackJack Wins: {player.stats.NonBlackJackWins}, Black Jack Wins: {player.stats.BlackJackWins}, Losses: {player.stats.Loss}, Pushes: {player.stats.Push}");
            foreach (var hand in player.hands)
            {
                var cards = "";

                foreach (var card in hand.Cards)
                {
                    cards += $" {card.CardValue}";
                }
                Console.WriteLine(cards);
            }

            
        }
        public void ShowDealer(Player dealer)
        {
            Console.WriteLine($"{dealer.name}");
            var cards = "";
            foreach (var card in dealer.hands[0].Cards)
            {
                cards += $" {card.CardValue}";
            }
            Console.WriteLine(cards);
        }
    }
}

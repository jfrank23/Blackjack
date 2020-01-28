using System;
using System.Threading;
using Blackjack.Core;
using Blackjack.Core.Game;
using Blackjack.Core.UserInteraction;

namespace BlackjackCLI.InputFromPlayer
{
    class DisplayCLI :IDisplayGame
    {
        public void DisplayGame(Game game)
        {
            Console.Clear();
            ShowDealer(game.dealer);
            foreach (var player in game.players)
            {
                ShowPlayer(player);
            }            
        }
        public void ShowPlayer(Player player)
        {
            Console.WriteLine($"{player.name} : ${player.Money}");
            var cards = "";
            foreach (var card in player.primaryHand.Cards)
            {
                cards += $" {card.CardValue}";
            }
            Console.WriteLine(cards);
        }
        public void ShowDealer(Player dealer)
        {
            Console.WriteLine($"{dealer.name}");
            var cards = "";
            foreach (var card in dealer.primaryHand.Cards)
            {
                cards += $" {card.CardValue}";
            }
            Console.WriteLine(cards);
        }
    }
}

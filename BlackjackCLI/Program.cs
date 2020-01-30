using Blackjack.Core.Game;
using BlackjackCLI.InputFromPlayer;
using Blackjack.Core.UserInteraction;

namespace BlackjackCLI
{
    class Program
    {

        static void Main(string[] args)
        {
            IInputFromPlayer inputFromPlayer = new InputFromPlayerCLI();
            IDisplayGame display = new DisplayCLI();
            var game = new Game(inputFromPlayer, display);
            var handsPlayed = 0;
            while (game.player.Money>0 || handsPlayed <=100)
            {
                game.PlayRound();
                handsPlayed += 1;
            }
        }
    }
}

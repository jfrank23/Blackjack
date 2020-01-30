namespace Blackjack.Core
{
    public class PlayerStats
    {
        public PlayerStats()
        {
            NonBlackJackWins = 0;
            Loss = 0;
            BlackJackWins = 0;
            Push = 0;
        }
        public int NonBlackJackWins { get; set; }
        public int Loss { get; set; }
        public int BlackJackWins { get; set; }
        public int Push { get; set; }
    }
}

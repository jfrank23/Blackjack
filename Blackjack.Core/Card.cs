using System;
using System.Collections.Generic;

namespace Blackjack.Core
{
    public class Shoe
    {
        public List<Card> Cards;
        public int NumberOfDecks;

    }
    public class Card
    {
        public CardValue CardValue{ get; set; }
        public Suit Suit { get; set; }

    }
}

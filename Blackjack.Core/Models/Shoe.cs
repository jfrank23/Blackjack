using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Core
{
    public class Shoe
    {
        public List<Card> Cards;
        public int NumberOfDecks;

        private Random random;

        public Shoe(int numberOfDecks)
        {
            NumberOfDecks = numberOfDecks;
            Cards = Shuffle(GenerateShoe());
        }

        public List<Card> Shuffle(IEnumerable<Card> cards)
        {
            random = new Random();
            var unShuffled = cards.ToList();
            var shuffled = new List<Card>();
            while (unShuffled.Count() > 0)
            {
                var index = random.Next(unShuffled.Count());
                var card = unShuffled[index];
                shuffled.Add(card);
                unShuffled.Remove(card);
            }

            return shuffled;
        }

        public List<Card> GenerateShoe()
        {
            var cards = new List<Card>();
            for(var decks = 0; decks < NumberOfDecks; decks++)
                foreach (var value in Enum.GetValues(typeof(CardValue)))
                    foreach (var suit in Enum.GetValues(typeof(Suit)))
                        cards.Add(new Card { CardValue = (CardValue)value, Suit = (Suit)suit });
            return cards;
        }
    }
}

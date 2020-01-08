using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Core
{
    public class Shoe
    {
        public List<Card> Cards;
        public int NumberOfDecks;
        public int Cut;

        private Random random;

        public Shoe(int numberOfDecks)
        {
            NumberOfDecks = numberOfDecks;
            Cards = Shuffle(GenerateShoe());
            Cut = GenerateCut();
        }
        public Card DealCard()
        {
            var cardDealt = Cards[0];
            Cards.Remove(cardDealt);
            return cardDealt;
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
        public int GenerateCut()
        {
            random = new Random();
            int halfwayInDeck = NumberOfDecks * 52 / 2;
            int totalCards = NumberOfDecks * 52;
            return random.Next(halfwayInDeck, totalCards);
        }
    }
}

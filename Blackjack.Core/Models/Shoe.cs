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
        public int CardsDealt;

        private Random random;

        public Shoe(int numberOfDecks)
        {
            CardsDealt = 0;
            NumberOfDecks = numberOfDecks;
            Cards = Shuffle(GenerateShoe());
            Cut = GenerateCut();
        }
        public Card DealCard()
        {
            var cardDealt = Cards[0];
            Cards.Remove(cardDealt);
            CardsDealt += 1;
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
        private int GenerateCut()
        {
            random = new Random();
            var mu = (int)Math.Round(NumberOfDecks * 52 * .75);
            var sigma = NumberOfDecks * 2;
            var u1 = random.NextDouble();
            var u2 = random.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);
           
            return (int)Math.Round(mu + sigma * rand_std_normal);
        }
    }
}

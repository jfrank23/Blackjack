using Blackjack.Core;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests.Models
{
    [TestFixture]
    public class ShoeTests
    {
        [Test]
        public void GenerateShoeTest()
        {
            var shoe = new Shoe(5);
            shoe.GenerateShoe().Count.Should().Be(5 * 52);
        }

        [Test]
        public void ShuffleShoeTest()
        {
            var cards = new List<Card>();
            for (var decks = 0; decks < 5; decks++)
                foreach (var value in Enum.GetValues(typeof(CardValue)))
                    foreach (var suit in Enum.GetValues(typeof(Suit)))
                        cards.Add(new Card { CardValue = (CardValue)value, Suit = (Suit)suit });

            var shoe = new Shoe(5);
            var shuffled = shoe.Shuffle(cards);

            shuffled.Should().NotEqual(cards);
            shuffled.Should().BeEquivalentTo(cards);

        }
    }
}
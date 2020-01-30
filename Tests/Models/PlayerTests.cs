using Blackjack.Core;
using Blackjack.Core.Strategies;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models
{
    [TestFixture]
    class PlayerTests
    {
        [TestCase(CardValue.Eight, CardValue.King, 18)]
        [TestCase(CardValue.Six, CardValue.King, 26)]
        public void PlayTest(CardValue card1Value,CardValue card2Value, int result)
        {
            var cardToDraw = new Card { CardValue = CardValue.Queen, Suit = Suit.Clubs };
            var shoe = new Shoe(1) { Cards = new List<Card> { cardToDraw }};
            var player = new Player(new DealerStrategy());
            var card1 = new Card { CardValue = card1Value, Suit = Suit.Spades };
            var card2 = new Card { CardValue = card2Value, Suit = Suit.Diamonds };
            player.primaryHand.AddCardToHand(card1);
            player.primaryHand.AddCardToHand(card2);
            player.PlayTurn(shoe).Should().Be(result);

        }
    }
}

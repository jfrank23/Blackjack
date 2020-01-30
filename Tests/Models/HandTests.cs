using Blackjack.Core;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models
{
    [TestFixture]
    public class HandTests
    {
        [TestCase(CardValue.Ace, CardValue.Eight,19)]
        [TestCase(CardValue.Ten, CardValue.Ten,20)]
        [TestCase(CardValue.Ten, CardValue.King,20)]
        [TestCase(CardValue.Five, CardValue.Three,8)]
        public void CountTestTwoCards(CardValue cardOne, CardValue cardTwo, int result)
        {
            var hand = new Hand(0);
            hand.AddCardToHand(new Card { CardValue = cardOne, Suit = Suit.Clubs });
            hand.AddCardToHand(new Card { CardValue = cardTwo, Suit = Suit.Diamonds });
            hand.Score.Should().Be(result);
        }
        [TestCase(CardValue.Ace, CardValue.Eight,CardValue.King, 19)]
        [TestCase(CardValue.Eight, CardValue.Five,CardValue.Ten, 23)]
        [TestCase(CardValue.King, CardValue.Five,CardValue.Ten, 25)]
        public void CountTestThreeCards(CardValue cardOne, CardValue cardTwo,CardValue cardThree, int result)
        {
            var hand = new Hand(0);
            hand.AddCardToHand(new Card { CardValue = cardOne, Suit = Suit.Clubs });
            hand.AddCardToHand(new Card { CardValue = cardTwo, Suit = Suit.Diamonds });
            hand.AddCardToHand(new Card { CardValue = cardThree, Suit = Suit.Hearts });
            hand.Score.Should().Be(result);
        }
    }
}

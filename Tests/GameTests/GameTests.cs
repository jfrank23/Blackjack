using Blackjack.Core.Game;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.GameTests
{
    [TestFixture]
    class GameTests
    {
        [Test]
        public void StartGameTest()
        {
            var game = new Game();
            game.StartGame();
            game.dealer.primaryHand.Cards.Count.Should().Be(2);
            game.player.primaryHand.Cards.Count.Should().Be(2);
        }
    }
}

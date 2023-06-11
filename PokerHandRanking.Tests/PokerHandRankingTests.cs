using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PokerHandRanking.Models;

namespace PokerHandRanking.Tests
{
    [TestClass]
    public class PokerHandRankingTests
    {
        private PokerHandRanking pokerHandRanking;

        [TestInitialize]
        public void TestInitialize()
        {
            pokerHandRanking = new PokerHandRanking(new HandValidator(), new HandLevelGenerator());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            pokerHandRanking = null;
        }

        #region Hand Level Tests

        [TestMethod]
        public void When_AJQKTenOfSameSuit_Then_ReturnRoyalFlush()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.King, Suit = Suit.Club },
                new Card() { Rank = Rank.Queen, Suit = Suit.Club },
                new Card() { Rank = Rank.Jack, Suit = Suit.Club },
                new Card() { Rank = Rank.Ten, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Royal Flush", result);
        }

        [TestMethod]
        public void When_FourCardsOfSameRank_Then_ReturnFourOfAKind()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.Ace, Suit = Suit.Heart },
                new Card() { Rank = Rank.Ace, Suit = Suit.Spade },
                new Card() { Rank = Rank.Ace, Suit = Suit.Diamond },
                new Card() { Rank = Rank.Ten, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Four of a Kind", result);
        }

        [TestMethod]
        public void When_NoMatch_Then_ReturnHighestRankCard()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Nine, Suit = Suit.Spade },
                new Card() { Rank = Rank.Jack, Suit = Suit.Heart },
                new Card() { Rank = Rank.Queen, Suit = Suit.Club },
                new Card() { Rank = Rank.King, Suit = Suit.Diamond },
                new Card() { Rank = Rank.Ace, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("King", result);
        }

        [TestMethod]
        public void When_TwoSetsOfTwoCardsOfSameRank_Then_ReturnTwoPair()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.Ace, Suit = Suit.Heart },
                new Card() { Rank = Rank.Three, Suit = Suit.Club },
                new Card() { Rank = Rank.Three, Suit = Suit.Heart },
                new Card() { Rank = Rank.Five, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Two Pair", result);
        }

        [TestMethod]
        public void When_FiveCardsOfSameSuitInSequenece_Then_ReturnStraightFlush()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Five, Suit = Suit.Club },
                new Card() { Rank = Rank.Four, Suit = Suit.Club },
                new Card() { Rank = Rank.Three, Suit = Suit.Club },
                new Card() { Rank = Rank.Two, Suit = Suit.Club },
                new Card() { Rank = Rank.Ace, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Straight Flush", result);
        }

        [TestMethod]
        public void When_LastFiveCardsOfDifferentSuitInSequenece_Then_ReturnStraight()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.King, Suit = Suit.Club },
                new Card() { Rank = Rank.Queen, Suit = Suit.Heart },
                new Card() { Rank = Rank.Jack, Suit = Suit.Spade },
                new Card() { Rank = Rank.Ten, Suit = Suit.Diamond },
                new Card() { Rank = Rank.Ace, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Straight", result);
        }

        [TestMethod]
        public void When_FirstFiveCardsOfDifferentSuitInSequenece_Then_ReturnStraight()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Five, Suit = Suit.Club },
                new Card() { Rank = Rank.Four, Suit = Suit.Heart },
                new Card() { Rank = Rank.Three, Suit = Suit.Spade },
                new Card() { Rank = Rank.Two, Suit = Suit.Diamond },
                new Card() { Rank = Rank.Ace, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Straight", result);
        }

        [TestMethod]
        public void When_OneSetOfTwoCardsOfSameRank_Then_ReturnOnePair()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.Ace, Suit = Suit.Heart },
                new Card() { Rank = Rank.Two, Suit = Suit.Spade },
                new Card() { Rank = Rank.Three, Suit = Suit.Diamond },
                new Card() { Rank = Rank.Four, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("One Pair", result);
        }

        [TestMethod]
        public void When_FiveCardsOfSameSuitAndNotInSequence_Then_ReturnFlush()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.Nine, Suit = Suit.Club },
                new Card() { Rank = Rank.Three, Suit = Suit.Club },
                new Card() { Rank = Rank.Four, Suit = Suit.Club },
                new Card() { Rank = Rank.Five, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Flush", result);
        }

        [TestMethod]
        public void WhenThreeCardsOfSameRankAndTwoCardsOfSameRank_Then_ReturnFullHouse()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.Ace, Suit = Suit.Heart },
                new Card() { Rank = Rank.Ace, Suit = Suit.Spade },
                new Card() { Rank = Rank.Jack, Suit = Suit.Club },
                new Card() { Rank = Rank.Jack, Suit = Suit.Heart }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Full House", result);
        }

        [TestMethod]
        public void When_ThreeCardsOfSameRank_Then_ReturnThreeOfAKind()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.Ace, Suit = Suit.Heart },
                new Card() { Rank = Rank.Ace, Suit = Suit.Spade },
                new Card() { Rank = Rank.Three, Suit = Suit.Diamond },
                new Card() { Rank = Rank.Four, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Three of a kind", result);
        }

        #endregion

        #region Hand Validation Tests

        [TestMethod]
        public void When_HandIsNull_Then_ReturnNoCardsInTheHand()
        {
            
            var result = pokerHandRanking.RankHand(null);

            Assert.AreEqual("No cards in the hand", result);
        }

        [TestMethod]
        public void When_LessThan5Cards_Then_ReturnInvalidNumberOfCardsMessage()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.King, Suit = Suit.Club },
                new Card() { Rank = Rank.Queen, Suit = Suit.Club },
                new Card() { Rank = Rank.Jack, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Only 5 cards allowed", result);
        }


        [TestMethod]
        public void When_MoreThan5Cards_Then_ReturnInvalidNumberOfCardsMessage()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.King, Suit = Suit.Club },
                new Card() { Rank = Rank.Queen, Suit = Suit.Club },
                new Card() { Rank = Rank.Jack, Suit = Suit.Club },
                new Card() { Rank = Rank.Ten, Suit = Suit.Club },
                new Card() { Rank = Rank.Ten, Suit = Suit.Heart }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("Only 5 cards allowed", result);
        }

        [TestMethod]
        public void When_MoreThanOneCardOfSameRankAndSuit_Then_ReturnInvalidCardsMessage()
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace, Suit = Suit.Club },
                new Card() { Rank = Rank.King, Suit = Suit.Club },
                new Card() { Rank = Rank.Queen, Suit = Suit.Club },
                new Card() { Rank = Rank.Jack, Suit = Suit.Club },
                new Card() { Rank = Rank.Jack, Suit = Suit.Club }
            };

            var result = pokerHandRanking.RankHand(hand);

            Assert.AreEqual("More than one card with the same rank and same suit", result);
        }

        #endregion
    }
}

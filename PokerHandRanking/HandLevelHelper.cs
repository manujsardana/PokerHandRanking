using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking
{
    internal class HandLevelHelper
    {
        public static bool AreCardsInSequence(List<Card> cards, bool takeSuitIntoAccount)
        {
            cards = cards.OrderBy(x => x.Rank).ToList();
            var dict = CreateDictionaryForStraightFlush();
            Suit? suit = null;
            Rank currentRank;
            Dictionary<Rank, Rank> nextRank = null;
            foreach (Card card in cards)
            {
                if (takeSuitIntoAccount)
                {
                    if (suit == null)
                        suit = card.Suit;
                    else if (suit != card.Suit)
                        return false;
                }


                if (nextRank == null)
                {
                    nextRank = dict[card.Rank];
                    continue;
                }
                else
                {
                    currentRank = card.Rank;
                    if (nextRank.TryGetValue(currentRank, out var val))
                    {
                        nextRank = dict[currentRank];
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static Dictionary<Rank, Dictionary<Rank, Rank>> CreateDictionaryForStraightFlush()
        {
            return new Dictionary<Rank, Dictionary<Rank, Rank>>
            {
                { Rank.Ace, new Dictionary<Rank, Rank> { { Rank.Two, Rank.Two}, { Rank.Ten, Rank.Ten} } },
                { Rank.Two, new Dictionary<Rank, Rank> { { Rank.Three, Rank.Three } } },
                { Rank.Three, new Dictionary<Rank, Rank> { { Rank.Four, Rank.Four } } },
                { Rank.Four, new Dictionary<Rank, Rank> { { Rank.Five, Rank.Five } } },
                { Rank.Five, new Dictionary<Rank, Rank> { { Rank.Six, Rank.Six } } },
                { Rank.Six, new Dictionary<Rank, Rank> { { Rank.Seven, Rank.Seven } } },
                { Rank.Seven, new Dictionary<Rank, Rank> { { Rank.Eight, Rank.Eight } } },
                { Rank.Eight, new Dictionary<Rank, Rank> { { Rank.Nine, Rank.Nine } } },
                { Rank.Nine, new Dictionary<Rank, Rank> { { Rank.Ten, Rank.Ten } } },
                { Rank.Ten, new Dictionary<Rank, Rank> { { Rank.Jack, Rank.Jack } } },
                { Rank.Jack, new Dictionary<Rank, Rank> { { Rank.Queen, Rank.Queen } } },
                { Rank.Queen, new Dictionary<Rank, Rank> { { Rank.King, Rank.King } } },
                { Rank.King, new Dictionary<Rank, Rank> { { Rank.Ace, Rank.Ace } } }
            };
        }
    }
}

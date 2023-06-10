using PokerHandRanking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking.HandLevels
{
    internal class FourOfAKInd : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            var cardsGroupedByRank = cards.GroupBy(x => x.Rank);

            if (cardsGroupedByRank.Count() == 2)
            {
                var firstGroup = cardsGroupedByRank.First();
                var secondGroup = cardsGroupedByRank.Last();

                if (firstGroup.Count() == 4 || secondGroup.Count() == 4)
                {
                    return new HandLevelMatchDetails { HandLevelName = "Four of a Kind", IsMatch = true };
                }

            }

            return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };
        }
    }
}

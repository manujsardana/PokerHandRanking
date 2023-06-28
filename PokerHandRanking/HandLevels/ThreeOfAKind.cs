using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// Three cards of same Rank.
    /// </summary>
    internal class ThreeOfAKind : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            var cardsByRank = cards.GroupBy(x => x.Rank).ToList();

            foreach(var group in cardsByRank)
            {
                if(group.Count() == 3)
                    return new HandLevelMatchDetails { HandLevelName = "Three of a kind", IsMatch = true };
            }

            return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };
        }
    }
}

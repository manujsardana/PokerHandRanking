using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// Three cards of same Rank + Two cards of same Rank.
    /// </summary>
    internal class FullHouse : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {

            var cardsByRank = cards.GroupBy(x => x.Rank).ToList();

            if(cardsByRank.Count == 2)
            {
                if((cardsByRank[0].Count() == 3 && cardsByRank[1].Count() == 2) || (cardsByRank[0].Count() == 2 && cardsByRank[1].Count() == 3))
                        return new HandLevelMatchDetails { IsMatch = true, HandLevelName = "Full House" };
            }

            return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };
        }
    }
}

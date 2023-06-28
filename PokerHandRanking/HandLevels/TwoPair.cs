using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// Two sets of two cards of same Rank.
    /// </summary>
    internal class TwoPair : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            var cardsByRank = cards.GroupBy(x => x.Rank).ToList();

            int count = 0;
            foreach(var group in cardsByRank)
            {
                if(group.Count() >= 2) 
                    count++;

                if(count == 2)
                    return new HandLevelMatchDetails { IsMatch = true, HandLevelName = "Two Pair" };
            }
            
            return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };
        }
    }
}

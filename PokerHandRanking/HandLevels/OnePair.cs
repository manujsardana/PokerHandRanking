using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// One set of two cards of same Rank.
    /// </summary>
    internal class OnePair : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            Dictionary<Rank, int> rankCountdictionary = new Dictionary<Rank, int>();

            foreach (Card card in cards)
            {
                if (rankCountdictionary.TryGetValue(card.Rank, out int val))
                {
                    if (val == 1)
                    {
                        return new HandLevelMatchDetails { HandLevelName = "One Pair", IsMatch = true };
                    }
                    rankCountdictionary[card.Rank] = val + 1;
                }
                else
                    rankCountdictionary.Add(card.Rank, 1);
            }

            return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };
        }
    }
}

using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// Two sets of two cards of same Rank.
    /// </summary>
    internal class TwoPair : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            Dictionary<Rank, int> rankCountdictionary = new Dictionary<Rank, int>();

            foreach (Card card in cards)
            {
                if (rankCountdictionary.TryGetValue(card.Rank, out int val))
                {
                    rankCountdictionary[card.Rank] = val + 1;
                }
                else
                    rankCountdictionary.Add(card.Rank, 1);
            }

            if (rankCountdictionary.Count == 2 || rankCountdictionary.Count == 3)
            {
                return new HandLevelMatchDetails { IsMatch = true, HandLevelName = "Two Pair" };
            }
            else
                return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };
        }
    }
}

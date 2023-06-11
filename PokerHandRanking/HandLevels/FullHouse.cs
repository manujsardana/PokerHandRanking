using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// Three cards of same Rank + Two cards of same Rank.
    /// </summary>
    internal class FullHouse : IHandLevel
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

            if (rankCountdictionary.Count == 2)
            {
                return new HandLevelMatchDetails { IsMatch = true, HandLevelName = "Full House" };
            }
            else
                return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };


        }
    }
}

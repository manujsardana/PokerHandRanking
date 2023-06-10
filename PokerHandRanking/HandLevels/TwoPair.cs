using PokerHandRanking.Interfaces;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
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

using PokerHandRanking.Interfaces;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
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

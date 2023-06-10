using PokerHandRanking.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking.HandLevels
{
    internal class Straight : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            cards = cards.OrderBy(x => x.Rank).ToList();
            int count = -1;
            foreach (Card card in cards)
            {
                int currentRank = (int)card.Rank;
                if (count == -1)
                {
                    count = currentRank;
                    count++;
                }
                else if (count == currentRank)
                {
                    count++;
                    continue;
                }
                else
                    return new HandLevelMatchDetails { HandLevelName = string.Empty, IsMatch = false };

            }

            return new HandLevelMatchDetails { HandLevelName = "Straight", IsMatch = true };

        }
    }
}

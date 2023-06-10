using PokerHandRanking.Interfaces;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    internal class StraightFlush : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            if(HandLevelHelper.AreCardsInSequence(cards, true))
            {
                return new HandLevelMatchDetails { HandLevelName = "Straight Flush", IsMatch = true };
            }
            else
                return new HandLevelMatchDetails { HandLevelName = string.Empty, IsMatch = false };
        }
    }
}

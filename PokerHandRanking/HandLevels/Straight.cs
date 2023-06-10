using PokerHandRanking.Interfaces;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    internal class Straight : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {

            if(HandLevelHelper.AreCardsInSequence(cards, false))
            {
                return new HandLevelMatchDetails { HandLevelName = "Straight", IsMatch = true };
            }
            else
                return new HandLevelMatchDetails { HandLevelName = string.Empty, IsMatch = false };

        }
    }
}

using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// Five cards in sequence of different suit.
    /// </summary>
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

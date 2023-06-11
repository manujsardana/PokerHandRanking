using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// Five Cards of Same Suit.
    /// </summary>
    internal class Flush : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            // We could have also used cards.GroupBy(x => x.Suit) and then checked that the number of items should be five.
            Suit? suit = null;
            foreach (var card in cards)
            {
                if (suit == null)
                    suit = card.Suit;
                else if (suit == card.Suit)
                    continue;
                else
                    return new HandLevelMatchDetails { HandLevelName = string.Empty, IsMatch = false };
            }

            return new HandLevelMatchDetails { IsMatch = true, HandLevelName = "Flush" };
        }
    }
}

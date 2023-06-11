using PokerHandRanking.Interfaces;
using PokerHandRanking.Models;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    /// <summary>
    /// Cards A, J, Q, K and 10 of same suit.
    /// </summary>
    internal class RoyalFlush : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            var dictionaryForRoyalFlushCards = CreateDictionary();

            Suit? suit = null;
            foreach (var card in cards)
            {
                if (suit == null)
                    suit = card.Suit;
                else if (suit != card.Suit)
                    return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };

                if (dictionaryForRoyalFlushCards.ContainsKey(card.Rank))
                {
                    dictionaryForRoyalFlushCards.Remove(card.Rank);
                }
                else
                    return new HandLevelMatchDetails { IsMatch = false, HandLevelName = string.Empty };

            }

            return new HandLevelMatchDetails { IsMatch = true, HandLevelName = "Royal Flush" };
        }

        private Dictionary<Rank, Rank> CreateDictionary()
        {
            return new Dictionary<Rank, Rank>
            {
                { Rank.Ace, Rank.Ace },
                { Rank.King, Rank.King },
                { Rank.Queen, Rank.Queen },
                { Rank.Jack, Rank.Jack },
                { Rank.Ten, Rank.Ten}
            };
        }
    }
}

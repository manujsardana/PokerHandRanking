using PokerHandRanking.Interfaces;
using System.Collections.Generic;

namespace PokerHandRanking.HandLevels
{
    internal class HighestRank : IHandLevel
    {
        public HandLevelMatchDetails IsHandLevelMatch(List<Card> cards)
        {
            // This is the logic assuming that the order of the cards is as defined in the Rank enum - Ace  as lowest and King as highest
            int rank = -1;
            foreach (Card card in cards)
            {
                int currentRank = (int)card.Rank;
                if (rank == -1)
                    rank = currentRank;
                else if (rank > currentRank)
                    continue;
                else
                    rank = currentRank;
            }

            return new HandLevelMatchDetails { HandLevelName = ((Rank)rank).ToString(), IsMatch = true };
        }

        public HandLevelMatchDetails IsHandLevelMatchWithAceAsHighest(List<Card> cards)
        {
            // This is the logic assuming that the order of the cards is where Ace is the highest and two is lowest
            var rankOrderDictionary = CreateRankOrderDictionary();
            int rank = -1;
            Rank? highestRank = null;
            foreach (Card card in cards)
            {
                int currentRank = rankOrderDictionary[card.Rank];
                if (rank == -1)
                {
                    rank = currentRank;
                    highestRank = card.Rank;
                }
                else if (rank > currentRank)
                    continue;
                else
                {
                    rank = currentRank;
                    highestRank = card.Rank;
                }
            }



            return new HandLevelMatchDetails { HandLevelName = highestRank.ToString(), IsMatch = true };
        }

        private Dictionary<Rank, int> CreateRankOrderDictionary()
        {
            return new Dictionary<Rank, int>
            {
                { Rank.Ace, 13},
                { Rank.King, 12},
                { Rank.Queen, 11 },
                { Rank.Jack, 10 },
                { Rank.Ten, 9 },
                { Rank.Nine, 8 },
                { Rank.Eight, 7 },
                { Rank.Seven, 6 },
                { Rank.Six, 5 },
                { Rank.Five, 4 },
                { Rank.Four, 3 },
                { Rank.Three, 2 },
                { Rank.Two, 1 }
            };
        }
    }
}

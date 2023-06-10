using PokerHandRanking.HandLevels;
using PokerHandRanking.Interfaces;
using System.Collections.Generic;

namespace PokerHandRanking
{
    public class HandLevelGenerator : IHandLevelGenerator
    {
        public IEnumerable<IHandLevel> GetHandLevels()
        {
            yield return new RoyalFlush();
        }
    }
}

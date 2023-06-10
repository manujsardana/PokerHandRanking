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
            yield return new StraightFlush();
            yield return new FourOfAKInd();
            yield return new FullHouse();
            yield return new Flush();
            yield return new Straight();
            yield return new ThreeOfAKind();
            yield return new TwoPair();
            yield return new OnePair();
            yield return new HighestRank();
        }
    }
}

using System.Collections.Generic;

namespace PokerHandRanking.Interfaces
{
    public interface IHandLevelGenerator
    {
        IEnumerable<IHandLevel> GetHandLevels();
    }
}

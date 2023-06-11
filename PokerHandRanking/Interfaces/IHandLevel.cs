using PokerHandRanking.Models;
using System.Collections.Generic;

namespace PokerHandRanking.Interfaces
{
    public interface IHandLevel
    {
        HandLevelMatchDetails IsHandLevelMatch(List<Card> cards);
    }
}

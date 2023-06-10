using System.Collections.Generic;

namespace PokerHandRanking.Interfaces
{
    public interface IHandValidator
    {
        HandValidationDetails IsHandValid(List<Card> cards);
    }
}

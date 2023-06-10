using PokerHandRanking.Interfaces;
using System.Collections.Generic;

namespace PokerHandRanking
{
    public class HandValidator : IHandValidator
    {
        public HandValidationDetails IsHandValid(List<Card> cards)
        {
            if (cards.Count != 5)
                return new HandValidationDetails { IsValid = false, ValidationMessage = "Only 5 cards allowed" };


            var validationResult = IsMoreThanOneCardWIthSameRankAndSuit(cards);

            if (!validationResult.IsValid)
                return validationResult;

            return new HandValidationDetails { IsValid = true, ValidationMessage = string.Empty };
        }

        private HandValidationDetails IsMoreThanOneCardWIthSameRankAndSuit(List<Card> cards)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var card in cards)
            {
                var key = card.Suit.ToString() + card.Rank.ToString();
                if (result.ContainsKey(key))
                    return new HandValidationDetails { IsValid = false, ValidationMessage = "More than one card with the same rank and same suit" };
                else
                    result.Add(key, key);
            }

            return new HandValidationDetails { IsValid = true, ValidationMessage = string.Empty };
        }
    }
}

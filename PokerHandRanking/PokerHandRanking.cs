using PokerHandRanking.Interfaces;
using System.Collections.Generic;
using PokerHandRanking.Models;

namespace PokerHandRanking
{
    public class PokerHandRanking
    {
        private readonly IHandValidator _handValidator;
        private readonly IHandLevelGenerator _handLevelGenerator;

        public PokerHandRanking(IHandValidator handValidator, IHandLevelGenerator handLevelGenerator)
        {
            _handValidator = handValidator;
            _handLevelGenerator = handLevelGenerator;
        }

        public string RankHand(List<Card> hand)
        {
            if (hand == null) return "No cards in the hand";

            var handValidationDetails = _handValidator.IsHandValid(hand);
            if (!handValidationDetails.IsValid)
            {
                return handValidationDetails.ValidationMessage;
            }
            else
            {
                foreach (var handLevel in _handLevelGenerator.GetHandLevels())
                {
                    var handLevelMatchDetails = handLevel.IsHandLevelMatch(hand);

                    if (handLevelMatchDetails.IsMatch)
                        return handLevelMatchDetails.HandLevelName;
                    else
                        continue;

                }
            }

            return "None of the Levels match";

        }
    }
}

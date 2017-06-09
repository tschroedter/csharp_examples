using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsTwoPairsCondition
        : BaseCardValidatorCondition <ITwoPairsValidator>,
          IIsTwoPairsCondition
    {
        public IsTwoPairsCondition(
            [NotNull] ITwoPairsValidator validator)
            : base(validator)
        {
        }
    }
}
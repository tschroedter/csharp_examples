using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsTwoPairs
        : BaseCardValidatorCondition <ITwoPairsValidator>,
          IIsTwoPairs
    {
        public IsTwoPairs(
            [NotNull] ITwoPairsValidator validator)
            : base(validator)
        {
        }
    }
}
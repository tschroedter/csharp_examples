using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsThreeOfAKindCondition
        : BaseCardValidatorCondition <IThreeCardsWithSameValueValidator>,
          IIsThreeOfAKindCondition
    {
        public IsThreeOfAKindCondition(
            [NotNull] IThreeCardsWithSameValueValidator validator)
            : base(validator)
        {
        }
    }
}
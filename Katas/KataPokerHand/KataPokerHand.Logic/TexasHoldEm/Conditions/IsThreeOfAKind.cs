using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsThreeOfAKind
        : BaseCardValidatorCondition <IThreeCardsWithSameValueValidator>,
          IIsThreeOfAKind
    {
        public IsThreeOfAKind(
            [NotNull] IThreeCardsWithSameValueValidator validator)
            : base(validator)
        {
        }
    }
}
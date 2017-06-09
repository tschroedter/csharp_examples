using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsFourCardsSameValueCondition
        : BaseCardValidatorCondition <IFourCardsWithSameValueValidator>,
          IIsFourCardsSameValueCondition
    {
        public IsFourCardsSameValueCondition(
            [NotNull] IFourCardsWithSameValueValidator validator)
            : base(validator)
        {
        }
    }
}
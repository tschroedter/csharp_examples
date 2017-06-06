using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsFourCardsSameValue
        : BaseCardValidatorCondition <IFourCardsWithSameValueValidator>,
          IIsFourCardsSameValue
    {
        public IsFourCardsSameValue(
            [NotNull] IFourCardsWithSameValueValidator validator)
            : base(validator)
        {
        }
    }
}
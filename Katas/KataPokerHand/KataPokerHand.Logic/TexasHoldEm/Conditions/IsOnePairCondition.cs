using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsOnePairCondition
        : BaseCardValidatorCondition <IOnePairValidator>,
          IIsOnePairCondition
    {
        public IsOnePairCondition(
            [NotNull] IOnePairValidator validator)
            : base(validator)
        {
        }
    }
}
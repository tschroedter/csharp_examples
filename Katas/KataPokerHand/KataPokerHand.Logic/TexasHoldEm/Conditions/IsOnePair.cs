using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsOnePair
        : BaseCardValidatorCondition <IOnePairValidator>,
          IIsOnePair
    {
        public IsOnePair(
            [NotNull] IOnePairValidator validator)
            : base(validator)
        {
        }
    }
}
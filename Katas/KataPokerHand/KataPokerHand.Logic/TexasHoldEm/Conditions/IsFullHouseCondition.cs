using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsFullHouseCondition
        : BaseCardValidatorCondition <IFullHouseValidator>,
          IIsFullHouseCondition
    {
        public IsFullHouseCondition(
            [NotNull] IFullHouseValidator validator)
            : base(validator)
        {
        }
    }
}
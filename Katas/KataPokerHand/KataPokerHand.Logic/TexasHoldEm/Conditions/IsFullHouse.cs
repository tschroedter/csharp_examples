using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsFullHouse
        : BaseCardValidatorCondition <IFullHouseValidator>,
          IIsFullHouse
    {
        public IsFullHouse(
            [NotNull] IFullHouseValidator validator)
            : base(validator)
        {
        }
    }
}
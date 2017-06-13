using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsFullHouseRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsFullHouseRule(
            [NotNull] IIsFullHouseCondition fullHouseCondition,
            [NotNull] IFullHouseValidator validator)
        {
            m_FullHouseCondition = fullHouseCondition;
            m_Validator = validator;
        }

        [NotNull]
        private readonly IIsFullHouseCondition m_FullHouseCondition;

        [NotNull]
        private readonly IFullHouseValidator m_Validator;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            m_Validator.Cards = info.Cards;
            if ( !m_Validator.IsValid() )
            {
                return info;
            }

            info.Status = Status.FullHouse;
            info.TwoOfAKind = m_Validator.TwoOfAKind;
            info.ThreeOfAKind = m_Validator.ThreeOfAKind;

            return info;
        }

        public override void Initialize(IPlayerHandInformation info)
        {
            m_FullHouseCondition.Cards = info.Cards;

            Conditions.Add(m_FullHouseCondition);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.FullHouse;
        }
    }
}
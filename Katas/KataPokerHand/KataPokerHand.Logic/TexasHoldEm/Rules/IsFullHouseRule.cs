using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
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
            [NotNull] IIsFullHouse fullHouse,
            [NotNull] IFullHouseValidator validator)
        {
            m_FullHouse = fullHouse;
            m_Validator = validator;
        }

        [NotNull]
        private readonly IIsFullHouse m_FullHouse;

        [NotNull]
        private readonly IFullHouseValidator m_Validator;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            m_Validator.Cards = info.PlayerHand.Cards;
            if ( m_Validator.IsValid() )
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
            m_FullHouse.Cards = info.PlayerHand.Cards;

            Conditions.Add(m_FullHouse);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.FullHouse;
        }
    }
}
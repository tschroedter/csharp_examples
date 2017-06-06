using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsThreeOfAKindRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsThreeOfAKindRule(
            [NotNull] IIsThreeOfAKind fullHouse,
            [NotNull] IThreeCardsWithSameValueValidator validator)
        {
            m_FullHouse = fullHouse;
            m_Validator = validator;
        }

        [NotNull]
        private readonly IIsThreeOfAKind m_FullHouse;

        [NotNull]
        private readonly IThreeCardsWithSameValueValidator m_Validator;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            m_Validator.Cards = info.PlayerHand.Cards;
            if ( !m_Validator.IsValid() )
            {
                return info;
            }

            info.Status = Status.ThreeOfAKind;
            info.Rank = m_Validator.Rank;
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
            return ( int ) RulesPriority.ThreeOfAKind;
        }
    }
}
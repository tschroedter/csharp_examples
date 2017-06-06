using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsTwoPairsRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsTwoPairsRule(
            [NotNull] IIsTwoPairs twoPairs,
            [NotNull] ITwoPairsValidator validator)
        {
            m_TwoPairs = twoPairs;
            m_Validator = validator;
        }

        [NotNull]
        private readonly IIsTwoPairs m_TwoPairs;

        [NotNull]
        private readonly ITwoPairsValidator m_Validator;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            m_Validator.Cards = info.PlayerHand.Cards;

            if ( !m_Validator.IsValid() )
            {
                return info;
            }

            info.Status = Status.TwoPairs;
            info.FirstPairOfCards = m_Validator.FirstPairOfCards;
            info.SecondPairOfCards = m_Validator.SecondPairOfCards;

            return info;
        }

        public override void Initialize(IPlayerHandInformation info)
        {
            m_TwoPairs.Cards = info.PlayerHand.Cards.ToArray();

            Conditions.Add(m_TwoPairs);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.TwoPairs;
        }
    }
}
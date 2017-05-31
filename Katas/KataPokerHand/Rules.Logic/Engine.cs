using System.Collections.Generic;
using JetBrains.Annotations;
using Rules.Logic.Interfaces;
using Rules.Logic.Interfaces.Rules;

namespace Rules.Logic
{
    public class Engine <T> : IEngine <T>
    {
        public Engine([NotNull] IRuleRepository <T> repository)
        {
            m_Repository = repository;
        }

        private readonly IRuleRepository <T> m_Repository;

        public void ApplyRules(IEnumerable <T> cells)
        {
            foreach ( T information in cells )
            {
                ApplyRulesToCellInformation(information);
            }
        }

        private void ApplyRulesToCellInformation(T information)
        {
            foreach ( IRule <T> rule in m_Repository.Rules )
            {
                rule.ClearConditions();
                rule.Initialize(information);

                if ( rule.IsValid() )
                {
                    rule.Apply(information);
                    break;
                }
            }
        }
    }
}
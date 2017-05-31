using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Rules.Logic.Interfaces.Rules;

namespace Rules.Logic
{
    public class RuleRepository <T> : IRuleRepository <T>
    {
        public RuleRepository([NotNull] IEnumerable <IRule <T>> rules)
        {
            Rules = rules.OrderBy(x => x.Priority).ToArray();
        }

        public IEnumerable <IRule <T>> Rules { get; }
    }
}
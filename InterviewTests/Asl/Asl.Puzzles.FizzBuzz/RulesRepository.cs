using System.Collections.Generic;
using System.Linq;
using Asl.Puzzles.FizzBuzz.Interfaces;
using Asl.Puzzles.FizzBuzz.Interfaces.Rules;
using JetBrains.Annotations;

namespace Asl.Puzzles.FizzBuzz
{
    public sealed class RulesRepository
        : IRulesRepository
    {
        public RulesRepository(
            [NotNull] IEnumerable <IRule> rules)
        {
            Rules = rules.OrderBy(x => x.Priority);
        }

        public IEnumerable <IRule> Rules { get; }
    }
}
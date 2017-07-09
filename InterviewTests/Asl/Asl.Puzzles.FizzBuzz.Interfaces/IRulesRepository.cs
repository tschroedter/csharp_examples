using System.Collections.Generic;
using Asl.Puzzles.FizzBuzz.Interfaces.Rules;
using JetBrains.Annotations;

namespace Asl.Puzzles.FizzBuzz.Interfaces
{
    public interface IRulesRepository
    {
        [NotNull]
        IEnumerable <IRule> Rules { get; }
    }
}
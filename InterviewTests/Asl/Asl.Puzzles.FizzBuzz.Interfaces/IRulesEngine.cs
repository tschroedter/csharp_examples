using JetBrains.Annotations;

namespace Asl.Puzzles.FizzBuzz.Interfaces
{
    public interface IRulesEngine
    {
        [NotNull]
        string Apply(int number);
    }
}
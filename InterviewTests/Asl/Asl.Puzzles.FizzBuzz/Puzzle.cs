using Asl.Puzzles.FizzBuzz.Interfaces;
using JetBrains.Annotations;

namespace Asl.Puzzles.FizzBuzz
{
    [UsedImplicitly]
    public sealed class Puzzle
        : IPuzzle
    {
        private readonly IRulesEngine m_Engine;

        public Puzzle(
            [NotNull] IRulesEngine engine)
        {
            m_Engine = engine;
        }

        public string FizzBuzz(int number)
        {
            return m_Engine.Apply(number);
        }
    }
}
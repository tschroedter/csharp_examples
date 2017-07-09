using System;
using Asl.Puzzles.FizzBuzz.Interfaces;
using Asl.Puzzles.FizzBuzz.Interfaces.Rules;
using JetBrains.Annotations;

namespace Asl.Puzzles.FizzBuzz
{
    [UsedImplicitly]
    public sealed class RulesEngine
        : IRulesEngine
    {
        private readonly IRulesRepository m_Repository;

        public RulesEngine(
            [NotNull] IRulesRepository repository)
        {
            m_Repository = repository;
        }

        public string Apply(int number)
        {
            foreach ( IRule rule in m_Repository.Rules )
            {
                if ( rule.CanApply(number) )
                {
                    return rule.Apply(number);
                }
            }

            throw new ArgumentException("Unknown number: " + number);
        }
    }
}
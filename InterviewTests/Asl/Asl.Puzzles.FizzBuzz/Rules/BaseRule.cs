using System;

namespace Asl.Puzzles.FizzBuzz.Rules
{
    public abstract class BaseRule
    {
        protected BaseRule(
            int priority)
        {
            Priority = priority;
        }

        public int Priority { get; }

        public bool CanApply(int number)
        {
            return CheckIfCanApply(number);
        }

        public string Apply(int number)
        {
            if ( CheckIfCanApply(number) )
            {
                return GetText(number);
            }

            throw new ArgumentException("Unknown number: " + number);
        }

        protected abstract bool CheckIfCanApply(int number);
        protected abstract string GetText(int number);
    }
}
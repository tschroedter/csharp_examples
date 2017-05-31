using System;
using System.Diagnostics.CodeAnalysis;

namespace PlayingCards
{
    [ExcludeFromCodeCoverage]
    public class PlayingCardsRandom : IRandom
    {
        private readonly Random m_Random = new Random(0);

        public int Next(int minValue,
                        int maxValue)
        {
            return m_Random.Next(minValue,
                                 maxValue);
        }

        public double NextDouble()
        {
            return m_Random.NextDouble();
        }
    }
}
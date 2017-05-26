using System;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MinesweeperRandom : IRandom
    {
        private readonly Random m_Random = new Random();

        public int Next(int minimum,
                        int maximum)
        {
            return m_Random.Next(minimum,
                                 maximum);
        }
    }
}
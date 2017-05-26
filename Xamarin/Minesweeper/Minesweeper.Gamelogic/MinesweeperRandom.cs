using System;
using Minesweeper.Gamelogic.Interfaces;
using Minesweeper.Gamelogic.Ioc;

namespace Minesweeper.Gamelogic
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
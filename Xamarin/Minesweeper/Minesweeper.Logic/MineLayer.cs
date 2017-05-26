using JetBrains.Annotations;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MineLayer : IMineLayer
    {
        public MineLayer([NotNull] IRandom random,
                         [NotNull] IMineField mineField)
        {
            m_Random = random;
            m_MineField = mineField;
        }

        private readonly IMineField m_MineField;
        private readonly IRandom m_Random;

        public void PutMinesAtRandomLocation(int numberOfMines)
        {
            for ( var i = 0 ; i < numberOfMines ; i++ )
            {
                int row;
                int column;

                do
                {
                    row = m_Random.Next(0,
                                        m_MineField.RowsCount);
                    column = m_Random.Next(0,
                                           m_MineField.ColumnsCount);
                }
                while ( m_MineField.IsMineAt(row,
                                             column) );

                m_MineField.PutMineAt(row,
                                      column);
            }
        }
    }
}
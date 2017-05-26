using System.Collections.Generic;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MineField : IMineField
    {
        public MineField(int numberOfRows,
                         int numberOfColumns)
        {
            m_Field = new Field <bool>(numberOfRows,
                                       numberOfColumns);
        }

        public delegate IMineField Factory(int numberOfRows,
                                           int numberOfColumns);

        private readonly Field <bool> m_Field;

        public int RowsCount
        {
            get
            {
                return m_Field.RowsCount;
            }
        }

        public int ColumnsCount
        {
            get
            {
                return m_Field.ColumnsCount;
            }
        }

        public void PutMineAt(int row,
                              int column)
        {
            m_Field [ row,
                      column ] = true;
        }

        public void RemoveMineAt(int row,
                                 int column)
        {
            m_Field [ row,
                      column ] = false;
        }

        public bool IsMineAt(int row,
                             int column)
        {
            return m_Field [ row,
                             column ];
        }

        public IEnumerable <bool> GetRowAt(int numberOfRow)
        {
            return m_Field.GetRowAt(numberOfRow);
        }

        public IEnumerable <IEnumerable <bool>> Rows()
        {
            return m_Field.Rows();
        }
    }
}
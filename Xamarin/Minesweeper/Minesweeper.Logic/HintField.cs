using System;
using JetBrains.Annotations;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class HintField : IHintField
    {
        public HintField([NotNull] Func <IMineField, IHintCompass> factory,
                         [NotNull] IMineField mineField)
        {
            m_HintCompass = factory(mineField);

            m_Field = ToHintField(mineField);
        }

        private readonly Field <int> m_Field;
        private readonly IHintCompass m_HintCompass;

        public int GetHintFor(int row,
                              int column)
        {
            return m_Field [ row,
                             column ];
        }

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

        private Field <int> ToHintField([NotNull] IMineField mineField)
        {
            var hints = new Field <int>(mineField.RowsCount,
                                        mineField.ColumnsCount);

            for ( var rows = 0 ; rows < hints.RowsCount ; rows++ )
                for ( var columns = 0 ; columns < hints.ColumnsCount ; columns++ )
                    hints [ rows,
                            columns ] = m_HintCompass.GetMineCountFor(rows,
                                                                      columns);

            return hints;
        }
    }
}
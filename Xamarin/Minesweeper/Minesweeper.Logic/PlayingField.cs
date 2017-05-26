using JetBrains.Annotations;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class PlayingField : IPlayingField
    {
        public PlayingField([NotNull] IMineField mineField)
        {
            m_MineField = mineField;
            m_FieldMask = new Field <bool>(mineField.RowsCount,
                                           mineField.ColumnsCount);

            Status = GameStatus.Player.SelectedFieldWithoutMine;
        }

        private readonly Field <bool> m_FieldMask;
        private readonly IMineField m_MineField;

        public bool HasPlayerWon()
        {
            return AreAllFieldsSelectedIncludingMines();
        }

        public void SelectField(int row,
                                int column)
        {
            m_FieldMask [ row,
                          column ] = true;

            UpdateStatus(row,
                         column);
        }

        public int RowsCount
        {
            get
            {
                return m_FieldMask.RowsCount;
            }
        }

        public int ColumnsCount
        {
            get
            {
                return m_FieldMask.ColumnsCount;
            }
        }

        public bool IsSelected(int row,
                               int column)
        {
            return m_FieldMask [ row,
                                 column ];
        }

        public GameStatus.Player Status { get; private set; }

        private bool AreAllFieldsSelectedIncludingMines()
        {
            for ( var row = 0 ; row < m_FieldMask.RowsCount ; row++ )
                for ( var column = 0 ; column < m_FieldMask.ColumnsCount ; column++ )
                {
                    bool isSelected = m_FieldMask [ row,
                                                    column ];

                    if ( isSelected )
                    {
                        continue;
                    }

                    if ( m_MineField.IsMineAt(row,
                                              column) )
                    {
                        continue;
                    }

                    return false;
                }

            return true;
        }

        private void UpdateStatus(int row,
                                  int column)
        {
            if ( HasPlayerWon() )
            {
                Status = GameStatus.Player.HasWon;
            }
            if ( m_MineField.IsMineAt(row,
                                      column) )
            {
                Status = GameStatus.Player.SelectedFieldWithMine;
            }
        }
    }
}
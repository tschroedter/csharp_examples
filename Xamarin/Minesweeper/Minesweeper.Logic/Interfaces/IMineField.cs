using System.Collections.Generic;

namespace Minesweeper.Logic.Interfaces
{
    public interface IMineField
    {
        int RowsCount { get; }
        int ColumnsCount { get; }

        IEnumerable <bool> GetRowAt(int numberOfRow);

        bool IsMineAt(int row,
                      int column);

        void PutMineAt(int row,
                       int column);

        void RemoveMineAt(int row,
                          int column);

        IEnumerable <IEnumerable <bool>> Rows();
    }
}
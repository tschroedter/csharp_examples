using System;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IMineFieldManager
    {
        GameStatus.Player Status { get; }
        int RowsCount { get; }
        int ColumsCount { get; }

        void UserSelectedField(int row,
                               int column);

        Tuple <int, int> AskUserForRowAndCoumn(int maximumNumberOfRows,
                                               int maximumNumberOfColumns);

        void DisplayPlayingField();

        void CreateMineField(int numberOfRows,
                             int numberOfColumns,
                             int numberOfMines);

        void CreateMineField(string numberOfRows);
    }
}
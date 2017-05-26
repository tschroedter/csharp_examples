using System;

namespace Minesweeper.Logic.Interfaces
{
    public interface IMineFieldManager
    {
        GameStatus.Player Status { get; }
        int RowsCount { get; }
        int ColumsCount { get; }
        IHintField HintField { get; } // todo hide HintField

        Tuple <int, int> AskUserForRowAndCoumn(int maximumNumberOfRows,
                                               int maximumNumberOfColumns);

        void CreateMineField(int numberOfRows,
                             int numberOfColumns,
                             int numberOfMines);

        void CreateMineField(string numberOfRows);

        void DisplayPlayingField();

        int GetHintFor(int row,
                       int column);

        void UserSelectedField(int row,
                               int column);
    }
}
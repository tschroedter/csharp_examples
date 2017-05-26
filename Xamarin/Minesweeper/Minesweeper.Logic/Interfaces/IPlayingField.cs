namespace Minesweeper.Logic.Interfaces
{
    public interface IPlayingField
    {
        int RowsCount { get; }

        int ColumnsCount { get; }
        GameStatus.Player Status { get; }

        bool HasPlayerWon();

        bool IsSelected(int row,
                        int column);

        void SelectField(int row,
                         int column);
    }
}
namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IHintField
    {
        int RowsCount { get; }
        int ColumnCount { get; }

        int GetHintFor(int row,
                       int column);
    }
}
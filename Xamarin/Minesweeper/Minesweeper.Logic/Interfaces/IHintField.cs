namespace Minesweeper.Logic.Interfaces
{
    public interface IHintField
    {
        int RowsCount { get; }
        int ColumnsCount { get; }

        int GetHintFor(int row,
                       int column);
    }
}
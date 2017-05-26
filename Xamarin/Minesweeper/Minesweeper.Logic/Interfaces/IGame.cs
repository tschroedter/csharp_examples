namespace Minesweeper.Logic.Interfaces
{
    public interface IGame
    {
        GameStatus.Player Status { get; }
        int RowsCount { get; }
        int ColumnsCount { get; }
        string GameStatusToString(GameStatus.Player status);

        int GetHintFor(int row,
                       int column);

        void Initialize(int numberOfRows,
                        int numberOfColumns,
                        int numberOfMines);

        bool IsGameFinished(GameStatus.Player status);

        bool PlayOneRound(int row,
                          int column);

        void Start();
    }
}
using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IGame
    {
        void Start();

        void Initialize(int numberOfRows,
                        int numberOfColumns,
                        int numberOfMines);

        void Initialize([NotNull] string text);
    }
}
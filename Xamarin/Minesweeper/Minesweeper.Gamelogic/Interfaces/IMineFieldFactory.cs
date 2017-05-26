using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IMineFieldFactory : ITypedFactory
    {
        IMineField Create(int numberOfRows,
                          int numberOfColumns);

        void Release([NotNull] IMineField mineField);
    }
}
using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IPlayingFieldFactory : ITypedFactory
    {
        IPlayingField Create([NotNull] IMineField mineField);
        void Release([NotNull] IPlayingField mineLayer);
    }
}
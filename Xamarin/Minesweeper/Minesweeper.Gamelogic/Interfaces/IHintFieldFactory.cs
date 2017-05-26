using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IHintFieldFactory : ITypedFactory
    {
        IHintField Create([NotNull] IMineField mineField);
        void Release([NotNull] IHintField mineLayer);
    }
}
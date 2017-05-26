using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IMineLayerFactory : ITypedFactory
    {
        IMineLayer Create([NotNull] IMineField mineField);
        void Release([NotNull] IMineLayer mineLayer);
    }
}
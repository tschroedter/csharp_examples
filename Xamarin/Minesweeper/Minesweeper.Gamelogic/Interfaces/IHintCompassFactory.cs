using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IHintCompassFactory
    {
        IHintCompass Create([NotNull] IMineField mineField);
        void Release([NotNull] IHintCompass hintCompass);
    }
}
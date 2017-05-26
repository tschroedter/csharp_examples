using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IConsole
    {
        void WriteLine([NotNull] string text);

        void WriteLine(string format,
                       params object[] args);
    }
}
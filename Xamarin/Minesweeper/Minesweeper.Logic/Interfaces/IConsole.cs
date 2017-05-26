using JetBrains.Annotations;

namespace Minesweeper.Logic.Interfaces
{
    public interface IConsole
    {
        string ReadLine();

        void Write(string inputRowColumn);
        void WriteLine([NotNull] string text);

        void WriteLine(string format,
                       params object[] args);
    }
}
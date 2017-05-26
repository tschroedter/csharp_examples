using JetBrains.Annotations;

namespace Minesweeper.Logic.Interfaces
{
    public interface IStringToMineFieldConverter
    {
        IMineField ToMineField([NotNull] string text);
    }
}
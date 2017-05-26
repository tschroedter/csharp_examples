using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IStringToMineFieldConverter
    {
        IMineField ToMineField([NotNull] string text);
    }
}
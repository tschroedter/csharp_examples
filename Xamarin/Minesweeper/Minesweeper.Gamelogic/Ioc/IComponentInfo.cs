using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Ioc
{
    public interface IComponentInfo
    {
        [NotNull]
        string Name { get; }

        Lifestyle Lifestyle { get; }
    }
}
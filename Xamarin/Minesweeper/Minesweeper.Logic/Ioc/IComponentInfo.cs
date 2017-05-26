using JetBrains.Annotations;

namespace Minesweeper.Logic.Ioc
{
    public interface IComponentInfo
    {
        [NotNull]
        string Name { get; }

        Lifestyle Lifestyle { get; }
    }
}
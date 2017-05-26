using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IDisplayPlayingFieldFactory : ITypedFactory
    {
        IDisplayPlayingField Create([NotNull] IHintField hintField,
                                    [NotNull] IPlayingField playingField);

        void Release([NotNull] IDisplayPlayingField mineLayer);
    }
}
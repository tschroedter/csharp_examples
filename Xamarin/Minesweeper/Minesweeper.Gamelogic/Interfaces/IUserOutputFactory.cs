using JetBrains.Annotations;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IUserOutputFactory : ITypedFactory
    {
        IUserOutput Create([NotNull] IHintField hintField,
                           [NotNull] IPlayingField playingField);

        void Release([NotNull] IDisplayPlayingField mineLayer);
    }
}
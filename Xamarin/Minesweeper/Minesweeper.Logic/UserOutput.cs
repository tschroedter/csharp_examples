using System;
using JetBrains.Annotations;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class UserOutput : IUserOutput
    {
        public UserOutput([NotNull] IConsole console,
                          [NotNull] Func <IHintField, IPlayingField, IDisplayPlayingField> factory,
                          [NotNull] IHintField hintField,
                          [NotNull] IPlayingField playingField)
        {
            m_Console = console;
            m_DisplayPlayingFieldField = factory(hintField,
                                                 playingField);
        }

        private readonly IConsole m_Console;
        private readonly IDisplayPlayingField m_DisplayPlayingFieldField;

        public void DisplayPlayingField()
        {
            m_Console.WriteLine("Minefield:");
            m_Console.WriteLine(m_DisplayPlayingFieldField.ToString());
        }
    }
}
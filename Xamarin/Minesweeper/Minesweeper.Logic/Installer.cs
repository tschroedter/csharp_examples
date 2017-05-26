using System.Reflection;
using Autofac;
using JetBrains.Annotations;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    public class Installer // todo
    {
        public Installer([NotNull] ContainerBuilder builder)
        {
            var logger = new MinesweeperLogger(); // todo logger
            var loader = new ProjectComponentLoader(logger);
            Assembly assembly = GetType().Assembly;

            loader.Load(builder,
                        assembly);
        }
    }
}
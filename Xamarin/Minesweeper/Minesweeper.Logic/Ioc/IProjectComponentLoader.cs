using System.Reflection;
using Autofac;
using JetBrains.Annotations;

namespace Minesweeper.Logic.Ioc
{
    public interface IProjectComponentLoader
    {
        void Load([NotNull] ContainerBuilder builder,
                  [NotNull] Assembly assembly);
    }
}
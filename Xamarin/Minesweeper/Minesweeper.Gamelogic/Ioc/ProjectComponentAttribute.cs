using System;

namespace Minesweeper.Gamelogic.Ioc
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class ProjectComponentAttribute
        : Attribute,
          IComponentInfo
    {
        public ProjectComponentAttribute()
            : this(Lifestyle.Singleton)
        {
            Name = GetType().FullName;
        }

        public ProjectComponentAttribute(Lifestyle lifestyle)
        {
            Lifestyle = lifestyle;
            Name = GetType().FullName;
        }

        public Lifestyle Lifestyle { get; private set; }

        public string Name { get; }
    }
}
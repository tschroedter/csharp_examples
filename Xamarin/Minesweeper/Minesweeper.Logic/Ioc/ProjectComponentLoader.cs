using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using JetBrains.Annotations;
using Minesweeper.Logic.Common;

namespace Minesweeper.Logic.Ioc
{
    public class ProjectComponentLoader : IProjectComponentLoader
    {
        public ProjectComponentLoader([NotNull] ILogger logger)
        {
            m_Logger = logger;
        }

        private readonly ILogger m_Logger;

        public virtual void Load([NotNull] ContainerBuilder builder,
                                 Assembly assembly)
        {
            m_Logger.Info("Loading ProjectComponent's for module '{0}'...".Inject(assembly.ManifestModule.Name));

            InstallLifestyleSingelton(builder,
                                      assembly);

            InstallLifestyleTransient(builder,
                                      assembly);

            InstallLifestyleStartable(builder,
                                      assembly);
        }

        protected static bool IsLifestyleSingelton(ProjectComponentAttribute component)
        {
            return ( component != null ) && ( component.Lifestyle == Lifestyle.Singleton );
        }

        protected static bool IsLifestyleStartable(ProjectComponentAttribute component)
        {
            return ( component != null ) && ( component.Lifestyle == Lifestyle.Startable );
        }

        protected static bool IsLifestyleTransient(ProjectComponentAttribute component)
        {
            return ( component != null ) && ( component.Lifestyle == Lifestyle.Transient );
        }

        protected bool IsLifestyle([NotNull] Type type,
                                   Func <ProjectComponentAttribute, bool> isLifestyle)
        {
            ProjectComponentAttribute[] attributes = GetProjectComponentAttributes(type);

            ProjectComponentAttribute[] selected = attributes.Where(isLifestyle).ToArray();

            LogAttributes(type,
                          selected);

            return selected.Any();
        }

        protected bool LifestyleSingelton([NotNull] Type type)
        {
            return IsLifestyle(type,
                               IsLifestyleSingelton);
        }

        protected bool LifestyleStartable([NotNull] Type type)
        {
            return IsLifestyle(type,
                               IsLifestyleStartable);
        }

        protected bool LifestyleTransient([NotNull] Type type)
        {
            return IsLifestyle(type,
                               IsLifestyleTransient);
        }

        private ProjectComponentAttribute[] GetProjectComponentAttributes(Type type)
        {
            object[] customAttributes = type.GetCustomAttributes(false);

            ProjectComponentAttribute[] projectComponentAttributes =
                customAttributes.Select(customAttribute => customAttribute as ProjectComponentAttribute)
                                .Where(x => x != null)
                                .ToArray();

            return projectComponentAttributes;
        }

        private void InstallLifestyleSingelton([NotNull] ContainerBuilder builder,
                                               Assembly assembly)
        {
            m_Logger.Info("{0}: LifestyleSingelton...".Inject(assembly.ManifestModule.Name));

            builder.RegisterAssemblyTypes(assembly)
                   .Where(LifestyleSingelton)
                   .AsImplementedInterfaces()
                   .SingleInstance();
        }

        private void InstallLifestyleStartable([NotNull] ContainerBuilder builder,
                                               Assembly assembly)
        {
            m_Logger.Info("{0}: LifestyleStartable...".Inject(assembly.ManifestModule.Name));

            builder.RegisterAssemblyTypes(assembly)
                   .Where(LifestyleStartable)
                   .AsImplementedInterfaces()
                   .As <IStartable>()
                   .SingleInstance();
        }

        private void InstallLifestyleTransient([NotNull] ContainerBuilder builder,
                                               Assembly assembly)
        {
            m_Logger.Info("{0}: LifestyleTransient...".Inject(assembly.ManifestModule.Name));

            builder.RegisterAssemblyTypes(assembly)
                   .Where(LifestyleTransient)
                   .AsImplementedInterfaces();
        }

        private bool IsNotUnitTestTypedFactory(Type type)
        {
            bool isUnitTest = type.FullName.Contains("NUnit") ||
                              type.FullName.Contains("XUnit");

            if ( !isUnitTest )
            {
                LogTypeAndLifestyle(type.FullName,
                                    "ITypedFactory");
            }

            return !isUnitTest;
        }

        private void LogAttributes([NotNull] Type type,
                                   [NotNull] ProjectComponentAttribute[] attributes)
        {
            if ( !attributes.Any() )
            {
                return;
            }

            var builder = new StringBuilder();

            foreach ( ProjectComponentAttribute customAttribute in attributes )
            {
                ProjectComponentAttribute componentAttribute = customAttribute;
                ProjectComponentAttribute attribute = componentAttribute;

                builder.Append("{0} ".Inject(attribute.Lifestyle));
            }

            LogTypeAndLifestyle(type.FullName,
                                builder.ToString());
        }

        private void LogTypeAndLifestyle(string type,
                                         string lifestyle)
        {
            m_Logger.Info("{0} has the following Lifestyle: {1}".Inject(type,
                                                                        lifestyle));
        }
    }
}
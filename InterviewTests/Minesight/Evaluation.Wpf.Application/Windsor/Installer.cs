﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Evaluation.Wpf.Application.Common;
using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.View.Interfaces;
using Evaluation.Wpf.Application.ViewModels.Common;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.Windsor
{
    [ExcludeFromCodeCoverage]
    public class Installer : IWindsorInstaller
    {
        public void Install([NotNull] IWindsorContainer container,
                            [NotNull] IConfigurationStore store)
        {
            RegisterWpfComponents(container);

            IEnumerable <Assembly> allAssemblies = AllAssembly().OrderBy(x => x.FullName).ToArray();

            DisplayAssemblies(allAssemblies);

            Assembly selkieWindsor = GetSelkieAssembly("Selkie.Windsor.dll",
                                                       allAssemblies); // need to install first, other depend on it
            Assembly easyNetQ = GetSelkieAssembly("Selkie.EasyNetQ.dll",
                                                  allAssemblies); // need to install second, other depend on it

            container.Install(FromAssembly.Instance(selkieWindsor));
            container.Install(FromAssembly.Instance(easyNetQ));

            foreach ( Assembly assembly in allAssemblies )
            {
                CallAssemblyInstaller(container,
                                      assembly);
            }

            // todo all this manual registration below will disappears when using seperate DLLs and installers for Models, ViewModels...
            // register Models
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn <IModel>()
                                      .WithServiceFromInterface(typeof( IModel ))
                                      .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));

            // register ViewModels
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn <IViewModel>()
                                      .WithServiceFromInterface(typeof( IViewModel ))
                                      .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));

            // register Views
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn <IView>()
                                      .WithServiceFromInterface(typeof( IView ))
                                      .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));

            // register others
            container.Register(Component.For <ICommandManager>()
                                        .ImplementedBy <CommandManager>());

            container.Register(Component.For <ISettingsManager>()
                                        .ImplementedBy <SettingsManager>());
        }

        protected virtual void InstallComponents([NotNull] IWindsorContainer container,
                                                 [NotNull] IConfigurationStore store)
        {
        }

        private static void AddDllsToAssemblyList([NotNull] IEnumerable <FileInfo> dlls,
                                                  [NotNull] ICollection <Assembly> allAssembly)
        {
            foreach ( FileInfo dllInfo in dlls )
            {
                if ( IsIgnored(dllInfo) )
                {
                    continue;
                }

                AssemblyName assemblyName = AssemblyName.GetAssemblyName(dllInfo.Name);

                if ( assemblyName.Name == dllInfo.Name )
                {
                    continue;
                }

                Assembly assm = Assembly.Load(assemblyName);

                allAssembly.Add(assm);
            }
        }

        private static void DisplayAssemblies(IEnumerable <Assembly> all)
        {
            Console.WriteLine("Running installers for the following assemblies:");

            foreach ( Assembly assembly in all )
            {
                Console.WriteLine(assembly.FullName);
            }
        }

        private static bool IsIgnored([NotNull] FileInfo dllInfo)
        {
            return dllInfo.Name.StartsWith("NSubstitute") || dllInfo.Name.StartsWith("NLog") ||
                   dllInfo.Name.StartsWith("NUnit") || dllInfo.Name.StartsWith("XUnit");
        }

        private static void RegisterWpfComponents(IWindsorContainer container)
        {
            container.AddFacility <ViewActivatorFacility>();
            container.Register(Component.For <IWindsorContainer>().Instance(container),
                               Component.For <IViewFactory>().ImplementedBy <WindsorViewFactory>());
        }

        [NotNull]
        private static IEnumerable <Assembly> AllAssembly()
        {
            var allAssembly = new List <Assembly>();

            string directory = AppDomain.CurrentDomain.BaseDirectory;

            var directoryrInfo = new DirectoryInfo(directory);

            FileInfo[] dlls = directoryrInfo.GetFiles("*.dll");

            AddDllsToAssemblyList(dlls,
                                  allAssembly);

            return allAssembly;
        }

        private void CallAssemblyInstaller([NotNull] IWindsorContainer container,
                                           [NotNull] Assembly assembly)
        {
            string name = assembly.ManifestModule.Name;

            Console.WriteLine("{0} - Checking...",
                              name);

            if ( IsIgnoredAssemblyName(name) )
            {
                Console.WriteLine("{0} - Ignored!",
                                  name);

                return;
            }

            if ( !name.StartsWith("Selkie.",
                                  StringComparison.Ordinal) &&
                 !name.StartsWith("Evaluation.",
                                  StringComparison.Ordinal) )
            {
                return;
            }

            Console.WriteLine("{0} - Processing...",
                              name);

            container.Install(FromAssembly.Instance(assembly));
        }

        [NotNull]
        private Assembly GetSelkieAssembly([NotNull] string assemblyName,
                                           [NotNull] IEnumerable <Assembly> all)
        {
            Assembly assembly = all.First(x => IsSelkieAssembly(assemblyName,
                                                                x));

            return assembly;
        }

        private bool IsIgnoredAssemblyName(string name)
        {
            return name.IndexOf("Console",
                                StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                   name.IndexOf("SpecFlow",
                                StringComparison
                                    .InvariantCultureIgnoreCase) >= 0 ||
                   name.IndexOf("Selkie.Windsor",
                                StringComparison
                                    .InvariantCultureIgnoreCase) >= 0 ||
                   name.IndexOf("Selkie.EasyNetQ",
                                StringComparison
                                    .InvariantCultureIgnoreCase) >= 0;
        }

        private bool IsSelkieAssembly([NotNull] string assemblyName,
                                      [NotNull] Assembly assembly)
        {
            string name = assembly.ManifestModule.Name;

            return IsSelkieAssemblyName(assemblyName,
                                        name);
        }

        private bool IsSelkieAssemblyName([NotNull] string assemblyName,
                                          string name)
        {
            return string.Compare(name,
                                  assemblyName,
                                  StringComparison.CurrentCultureIgnoreCase) == 0;
        }
    }
}
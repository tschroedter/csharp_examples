﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using NLog;
using Module = Autofac.Module;

namespace Asl.Puzzles.SuperMarketRegister.Common
{
    [ExcludeFromCodeCoverage]
    public class LoggingModule
        : Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
                                                              IComponentRegistration registration)
        {
            // Handle constructor parameters.
            registration.Preparing += OnComponentPreparing;

            // Handle properties.
            registration.Activated += (sender,
                                       e) => InjectLoggerProperties(e.Instance);
        }

        private static void InjectLoggerProperties(object instance)
        {
            Type instanceType = instance.GetType();

            // Get all the injectable properties to set.
            // If you wanted to ensure the properties were only UNSET properties,
            // here's where you'd do it.
            IEnumerable <PropertyInfo> properties = instanceType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(
                       p =>
                           ( p.PropertyType == typeof( ILogger ) ) && p.CanWrite &&
                           ( p.GetIndexParameters().Length == 0 ));

            // Set the properties located.
            foreach ( PropertyInfo propToSet in properties )
            {
                propToSet.SetValue(instance,
                                   LogManager.GetLogger(instanceType.FullName),
                                   null);
            }
        }

        private static void OnComponentPreparing(object sender,
                                                 PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(
                                              new[]
                                              {
                                                  new ResolvedParameter(
                                                                        (p,
                                                                         i) => p.ParameterType == typeof( ILogger ),
                                                                        (p,
                                                                         i) => LogManager
                                                                            // ReSharper disable once PossibleNullReferenceException
                                                                            .GetLogger(p.Member.DeclaringType.FullName)
                                                                       )
                                              });
        }
    }
}
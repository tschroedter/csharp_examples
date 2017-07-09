using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Rules;
using Autofac;
using JetBrains.Annotations;

namespace Asl.Puzzles.FizzBuzz
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class FizzBuzzModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType <FizzBuzzRule>().AsImplementedInterfaces();
            builder.RegisterType <BuzzRule>().AsImplementedInterfaces();
            builder.RegisterType <FizzRule>().AsImplementedInterfaces();
            builder.RegisterType <OtherNumberRule>().AsImplementedInterfaces();
            builder.RegisterType <RulesRepository>().AsImplementedInterfaces();
            builder.RegisterType <RulesEngine>().AsImplementedInterfaces();
            builder.RegisterType <Puzzle>().AsImplementedInterfaces();
        }
    }
}
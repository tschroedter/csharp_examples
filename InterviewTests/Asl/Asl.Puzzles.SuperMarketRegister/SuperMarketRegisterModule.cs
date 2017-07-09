using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.SuperMarketRegister.Aop;
using Asl.Puzzles.SuperMarketRegister.Common;
using Autofac;
using Autofac.Extras.DynamicProxy;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class SuperMarketRegisterModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType <Receipt>()
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof( AddItemAspect ));

            builder.RegisterType <ReceiptItemList>()
                   .AsImplementedInterfaces();
            builder.RegisterType <SubTotalCalculator>()
                   .AsImplementedInterfaces();
            builder.RegisterType <TaxTotalCalulator>()
                   .AsImplementedInterfaces();
            builder.RegisterType <TotalCalculator>()
                   .AsImplementedInterfaces();

            builder.RegisterType <AddItemArgumentsValidator>()
                   .AsImplementedInterfaces();

            builder.RegisterType <SuperMarketRegisterLogger>()
                   .AsImplementedInterfaces();

            builder.RegisterType <AddItemAspect>();
        }
    }
}
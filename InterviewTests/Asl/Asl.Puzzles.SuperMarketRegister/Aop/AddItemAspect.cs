using System;
using Asl.Puzzles.SuperMarketRegister.Interfaces.Aop;
using Asl.Puzzles.SuperMarketRegister.Interfaces.Common;
using Castle.DynamicProxy;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister.Aop
{
    public class AddItemAspect : IInterceptor
    {
        private readonly ISuperMarketRegisterLogger m_Logger;
        private readonly IAddItemArgumentsValidator m_Validator;

        public AddItemAspect(
            [NotNull] ISuperMarketRegisterLogger logger,
            [NotNull] IAddItemArgumentsValidator validator)
        {
            m_Logger = logger;
            m_Validator = validator;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                if ( invocation.Method.Name.StartsWith("AddItem") )
                {
                    m_Validator.Validate(invocation.Arguments);
                }

                invocation.Proceed();
            }
            catch ( Exception exception )
            {
                m_Logger.Error($"An error has occured: {exception.Message}",
                               exception);
            }
        }
    }
}
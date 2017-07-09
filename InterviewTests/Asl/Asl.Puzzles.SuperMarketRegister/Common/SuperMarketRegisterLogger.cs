using System;
using Asl.Puzzles.SuperMarketRegister.Interfaces.Common;
using JetBrains.Annotations;
using NLog;

namespace Asl.Puzzles.SuperMarketRegister.Common
{
    [UsedImplicitly]
    public class SuperMarketRegisterLogger
        : ISuperMarketRegisterLogger
    {
        [NotNull]
        private readonly ILogger m_Logger;

        public SuperMarketRegisterLogger(
            [NotNull] ILogger logger)
        {
            m_Logger = logger;
        }

        // todo add more methods on demand, see NLog.ILogger

        public void Error(string message,
                          Exception exception)
        {
            m_Logger.Error(exception,
                           message);
        }
    }
}
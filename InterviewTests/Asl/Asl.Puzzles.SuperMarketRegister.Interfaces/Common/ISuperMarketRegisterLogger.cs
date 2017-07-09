using System;

namespace Asl.Puzzles.SuperMarketRegister.Interfaces.Common
{
    public interface ISuperMarketRegisterLogger
    {
        void Error(string message,
                   Exception exception);
    }
}
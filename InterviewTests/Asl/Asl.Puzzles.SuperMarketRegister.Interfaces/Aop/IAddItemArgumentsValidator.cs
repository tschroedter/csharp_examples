using System.Collections.Generic;

namespace Asl.Puzzles.SuperMarketRegister.Interfaces.Aop
{
    public interface IAddItemArgumentsValidator
    {
        void Validate(IEnumerable <object> arguments);
    }
}
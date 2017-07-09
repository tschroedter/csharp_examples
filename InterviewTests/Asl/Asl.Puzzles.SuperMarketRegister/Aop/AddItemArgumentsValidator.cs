using System;
using System.Collections.Generic;
using System.Linq;
using Asl.Puzzles.SuperMarketRegister.Interfaces.Aop;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister.Aop
{
    [UsedImplicitly]
    public class AddItemArgumentsValidator
        : IAddItemArgumentsValidator
    {
        public void Validate(IEnumerable <object> arguments)
        {
            object[] enumerable = arguments as object[] ?? arguments.ToArray();

            var quantity = ( int ) enumerable [ 0 ];

            if ( quantity < 0 )
            {
                throw new ArgumentException(
                                            "Method argument 'quantity' must be 0 or greater than zero! - Given 'quantity' is " +
                                            quantity);
            }

            var itemDescription = ( string ) enumerable [ 1 ];

            if ( string.IsNullOrEmpty(itemDescription) )
            {
                throw new ArgumentException("Method argument 'itemDescription' must not be null or empty!");
            }

            var pricePerItem = ( double ) enumerable [ 2 ];

            if ( pricePerItem < 0 )
            {
                throw new ArgumentException(
                                            "Method argument 'pricePerItem' must be 0 or greater than zero! - Given 'pricePerItem' is " +
                                            pricePerItem);
            }
        }
    }
}
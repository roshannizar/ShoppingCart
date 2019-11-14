using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.Exceptions
{
    public class InsufficientStockQuantity:Exception
    {
        public InsufficientStockQuantity():base("Insufficient quantity!")
        {

        }
    }
}

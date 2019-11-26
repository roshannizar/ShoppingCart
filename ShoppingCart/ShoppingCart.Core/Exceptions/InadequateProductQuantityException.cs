using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.Exceptions
{
    public class InadequateProductQuantityException:Exception
    {
        public InadequateProductQuantityException():base("Ineduquate Quantity")
        {

        }
    }
}

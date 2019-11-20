using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.Exceptions
{
    public class IneduquateProductQuantityException:Exception
    {
        public IneduquateProductQuantityException():base("Ineduquate Quantity")
        {

        }
    }
}

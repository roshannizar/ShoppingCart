using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.Exceptions
{
    public class OrderNotFoundException:Exception
    {
        public OrderNotFoundException():base("Order details are empty or customer not found!")
        {

        }
    }
}

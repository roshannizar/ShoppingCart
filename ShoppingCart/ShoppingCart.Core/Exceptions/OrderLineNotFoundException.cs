using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.Exceptions
{
    public class OrderLineNotFoundException:Exception
    {
        public OrderLineNotFoundException():base("Order item is empty or no orde items found!")
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.Exceptions
{
    public class CustomerNotFoundException:Exception
    {
        public CustomerNotFoundException():base("Customer details are empty or customer not found!")
        {

        }
    }
}

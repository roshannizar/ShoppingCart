using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.Exceptions
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException():base("Product is empty or no product found!")
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.BusinessObjectModels
{
    public class ProductBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}

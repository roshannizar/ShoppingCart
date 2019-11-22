using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.BusinessObjectModels
{
    public class OrderLineBO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual ProductBO Products { get; set; }
        public int OrderId { get; set; }
        public virtual OrderBO Orders { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.BusinessObjectModels
{
    public class OrderBO
    {
        public int Id { get; set; }
        public virtual List<OrderLineBO> OrderItems { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerBO Customers { get; set; }
        public DateTime Date { get; set; }
        public StatusTypeBO Status { get; set; }
    }
}

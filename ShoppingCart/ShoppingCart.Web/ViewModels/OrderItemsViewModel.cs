using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Web.ViewModels
{
    public class OrderItemsViewModel
    {
        public int Id { get; set; }
        public ProductViewModel[] Products { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}

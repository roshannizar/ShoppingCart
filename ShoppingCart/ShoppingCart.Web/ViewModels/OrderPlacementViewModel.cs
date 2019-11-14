using ShoppingCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Web.ViewModels
{
    public class OrderPlacementViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date {get;set;}
        public List<OrderItemsViewModel> OrderItems { get; set; }
    }
}

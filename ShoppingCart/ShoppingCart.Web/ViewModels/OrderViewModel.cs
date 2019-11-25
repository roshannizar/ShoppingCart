using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Web.ViewModels
{
    public class OrderViewModel
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public StatusTypeViewModel Status { get; set; }
        public List<OrderItemsViewModel> OrderItems { get; set; }
        public CustomerViewModel Customers { get; set; }
    }
}

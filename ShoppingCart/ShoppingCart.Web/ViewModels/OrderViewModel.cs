using ShoppingCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Web.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel(int customerId,DateTime date)
        {
            CustomerId = customerId;
            Date = date;
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public StatusType Status { get; set; }
    }
}

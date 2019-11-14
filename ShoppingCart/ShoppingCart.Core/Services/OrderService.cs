using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Core.Exceptions;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Entity;

namespace ShoppingCart.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ShoppingCartDbContext db;

        public OrderService(ShoppingCartDbContext db) 
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public int Create(Order order)
        {
            try
            {
                db.Add(order);
                Commit();
                return order.Id;
            }
            catch(OrderNotFoundException)
            {
                throw new OrderNotFoundException();
            }
        }

        public int GetLastOrderId()
        {
            var query = db.Orders
                .Select(x => x.Id)
                .LastOrDefault();

            return query;
        }

        public Order GetOrder(int id)
        {
            var query = db.Orders.Find(id);

            return query;
        }

        public IEnumerable<Order> GetOrders()
        {
            var query = db.Orders.Include(c => c.Customers).ToList();
            return query;
        }
    }
}

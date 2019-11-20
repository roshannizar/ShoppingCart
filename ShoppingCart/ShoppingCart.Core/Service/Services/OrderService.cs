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

        public int CreateOrder(Order order)
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

        public void DeleteOrder(int id)
        {
            var order = GetOrderObject(id);

            db.Orders.Remove(order);
            Commit();
        }

        public int GetLastOrderId()
        {
            var query = db.Orders
                .Select(x => x.Id)
                .LastOrDefault();

            return query;
        }

        public IEnumerable<Order> GetOrder(int id)
        {
            var query = db.Orders.Include(c => c.Customers).Where(o => o.Id == id).ToList();

            return query;
        }

        public Order GetOrderObject(int id)
        {
            var query = db.Orders.Find(id);
            return query;
        }

        public IEnumerable<Order> GetOrders()
        {
            var query = db.Orders.Include(c => c.Customers).ToList();
            return query;
        }

        public void CreateOrderLine(OrderLine orderLine)
        {
            try
            {

                db.Add(orderLine);
                Commit();
            }
            catch (OrderLineNotFoundException)
            {
                throw new OrderLineNotFoundException();
            }
        }

        public OrderLine DeleteOrderLine(int id)
        {
            var orderline = GetOrderLineById(id);

            if (orderline != null)
            {
                db.OrderLines.Remove(orderline);
            }

            return orderline;
        }

        public IEnumerable<OrderLine> GetOrderLine(int id)
        {
            var query = db.OrderLines.Include(p => p.Products).Include(o => o.Orders).Where(o => o.OrderId == id).ToList();
            return query;
        }

        public OrderLine GetOrderLineById(int id)
        {
            var query = db.OrderLines.Find(id);
            return query;
        }

        public IEnumerable<OrderLine> GetOrderLines()
        {
            //var query = (from o in db.OrderLines
            //             join p in db.Products on o.ProductId equals p.Id
            //             select new {o,p});

            var query = db.OrderLines.Include(p => p.Products).ToList();

            return query;
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            var entry = db.Entry(orderLine);
            entry.State = EntityState.Modified;
            Commit();
        }
    }
}

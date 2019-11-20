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
        private readonly ProductService productService;

        public OrderService(ShoppingCartDbContext db) 
        {
            this.db = db;
            productService = new ProductService(db);
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
                var tempProduct = productService.GetProduct(orderLine.ProductId);

                if(orderLine.Quantity <= tempProduct.Quantity)
                {
                    var remainingStock = tempProduct.Quantity - orderLine.Quantity;
                    tempProduct.Quantity = remainingStock;

                    db.Add(orderLine);
                    Commit();

                    //Updating the product
                    productService.Update(tempProduct);
                }
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
            var tempProduct = productService.GetProduct(orderLine.ProductId);
            var tempOrderLine = GetOrderLineById(orderLine.Id);
            var tempDifference = tempOrderLine.Quantity - orderLine.Quantity;
            var productQuantityTemp = tempDifference + tempProduct.Quantity;

            if(tempDifference <= productQuantityTemp)
            {
                tempProduct.Quantity = productQuantityTemp;
                tempOrderLine.Quantity = orderLine.Quantity;

                var entry = db.Entry(tempProduct);
                entry.State = EntityState.Modified;
                Commit();

                productService.Update(tempProduct);
            }
            else
            {
                throw new IneduquateProductQuantityException();
            }
        }
    }
}

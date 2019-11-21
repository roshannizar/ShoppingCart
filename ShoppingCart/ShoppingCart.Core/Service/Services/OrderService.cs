using System;
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

        public void CreateOrder(Order order)
        {
            try
            {
                db.Orders.Add(order);
                Commit();

                foreach (var items in order.OrderItems)
                {

                    var tempProduct = productService.GetProduct(items.ProductId);

                    if (items.Quantity <= tempProduct.Quantity)
                    {
                        var remainingStock = tempProduct.Quantity - items.Quantity;
                        tempProduct.Quantity = remainingStock;

                        //Updating the product
                        productService.Update(tempProduct);
                    }
                }
            }
            catch(OrderNotFoundException)
            {
                throw new OrderNotFoundException();
            }
            catch(OrderLineNotFoundException)
            {
                throw new OrderLineNotFoundException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteOrder(int id)
        {
            try
            {
                var order = GetOrderObject(id);

                if(order.Status == StatusType.Confirmed)
                {
                    db.Orders.Remove(order);
                } 
                else
                {
                    var orderLineTemp = GetOrderLine(id);

                    foreach(var temp in orderLineTemp)
                    {
                        var tempProduct = productService.GetProduct(temp.ProductId);
                        var tempQuantity = tempProduct.Quantity + temp.Quantity;
                        tempProduct.Quantity = tempQuantity;
                        productService.Update(tempProduct);
                    }

                    db.Orders.Remove(order);
                }
                Commit();
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
            var query = db.Orders.Include(c => c.Customers).Include(ol => ol.OrderItems).ToList();
            return query;
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
            var query = db.OrderLines.Include(p => p.Products).ToList();
            return query;
        }

        public void UpdateOrder(OrderLine orderLine)
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

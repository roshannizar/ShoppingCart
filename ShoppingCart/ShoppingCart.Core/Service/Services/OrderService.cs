using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Core.Exceptions;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Models;

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

        public void CreateOrder(Order order)
        {
            try
            {
                
                //This method will add orderlines as well, since this entity has the orderline list
                db.Orders.Add(order);
                db.SaveChanges();

                foreach (var items in order.OrderItems)
                {
                    //Retrieving the product by id
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
            catch(IneduquateProductQuantityException)
            {
                throw new IneduquateProductQuantityException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                foreach (var items in order.OrderItems)
                {
                    var tempProduct = productService.GetProduct(items.ProductId);
                    var tempOrderLine = GetOrderLineById(items.Id);

                    var tempDifference = tempOrderLine.Quantity - items.Quantity;
                    var productQuantityTemp = tempDifference + tempProduct.Quantity;

                    if (tempDifference <= productQuantityTemp)
                    {
                        tempProduct.Quantity = productQuantityTemp;
                        tempOrderLine.Quantity = items.Quantity;

                        if (tempOrderLine.Quantity == 0)
                        {
                            DeleteOrderLine(tempOrderLine);
                        }
                        else
                        {
                            var entry = db.Entry(tempOrderLine);
                            entry.State = EntityState.Modified;
                            db.SaveChanges();
                        }

                        productService.Update(tempProduct);
                    }
                    else
                    {
                        throw new IneduquateProductQuantityException();
                    }
                }
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
                var order = GetSingleOrderById(id);

                if(order.Status == StatusType.Confirmed)
                {
                    db.Orders.Remove(order);
                } 
                else
                {
                    var orderLineTemp = GetOrderLineByOrderId(id);

                    foreach(var temp in orderLineTemp)
                    {
                        var tempProduct = productService.GetProduct(temp.ProductId);
                        var tempQuantity = tempProduct.Quantity + temp.Quantity;
                        tempProduct.Quantity = tempQuantity;
                        productService.Update(tempProduct);
                    }

                    db.Orders.Remove(order);
                }
                db.SaveChanges();
            }
            catch(OrderNotFoundException)
            {
                throw new OrderNotFoundException();
            }
        }

        public void DeleteOrderLine(OrderLine orderLine)
        {
            if (orderLine != null)
            {
                db.OrderLines.Remove(orderLine);
                db.SaveChanges();
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            var query = db.Orders.Include(c => c.Customers).Include(ol => ol.OrderItems).ToList();
            return query;
        }

        public IEnumerable<Order> GetOrderById(int id)
        {
            var query = db.Orders.Include(c => c.Customers).Where(o => o.Id == id).ToList();

            return query;
        }

        public IEnumerable<OrderLine> GetOrderLineByOrderId(int id)
        {
            var query = db.OrderLines.Include(p => p.Products).Include(o => o.Orders).Where(o => o.OrderId == id).ToList();
            return query;
        }

        public Order GetSingleOrderById(int id)
        {
            var query = db.Orders.Find(id);
            return query;
        }

        public OrderLine GetOrderLineById(int id)
        {
            var query = db.OrderLines.Find(id);
            return query;
        }
    }
}

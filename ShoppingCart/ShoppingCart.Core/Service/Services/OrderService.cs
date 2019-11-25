using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Core.BusinessObjectModels;
using ShoppingCart.Core.Exceptions;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Models;

namespace ShoppingCart.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ShoppingCartDbContext db;
        private readonly IMapper mapper;
        private readonly ProductService productService;

        public OrderService(ShoppingCartDbContext db,IMapper mapper) 
        {
            this.db = db;
            this.mapper = mapper;
            productService = new ProductService(db,mapper);
        }

        public void CreateOrder(OrderBO orderBO)
        {
            try
            {
                var order = mapper.Map<Order>(orderBO);
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

        public void UpdateOrder(OrderBO orderBO)
        {
            try
            {
                var order = mapper.Map<Order>(orderBO);
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
                var orderBO = GetSingleOrderById(id);
                var order = mapper.Map<Order>(orderBO);
                //Checks the confirmation
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

        public void DeleteOrderLine(OrderLineBO orderLineBO)
        {
            if (orderLineBO != null)
            {
                var orderLine = mapper.Map<OrderLine>(orderLineBO);
                db.OrderLines.Remove(orderLine);
                db.SaveChanges();
            }
        }

        public IEnumerable<OrderBO> GetOrders()
        {
            var query = db.Orders.Include(c => c.Customers).Include(ol => ol.OrderItems).ToList();

            

            return mapper.Map<IEnumerable<OrderBO>>(query);
        }

        public IEnumerable<OrderBO> GetOrderById(int id)
        {
            var query = db.Orders.Include(c => c.Customers).Where(o => o.Id == id).ToList();

            return mapper.Map<IEnumerable<OrderBO>>(query);
        }

        public IEnumerable<OrderLineBO> GetOrderLineByOrderId(int id)
        {
            var query = db.OrderLines.Include(p => p.Products).Include(o => o.Orders).Where(o => o.OrderId == id).ToList();
            return mapper.Map<IEnumerable<OrderLineBO>>(query);
        }

        public OrderBO GetSingleOrderById(int id)
        {
            var query = db.Orders.Find(id);
            return mapper.Map<OrderBO>(query);
        }

        public OrderLineBO GetOrderLineById(int id)
        {
            var query = db.OrderLines.Find(id);
            return mapper.Map<OrderLineBO>(query);
        }
    }
}

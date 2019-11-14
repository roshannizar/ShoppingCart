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
    public class OrderLineService : IOrderLineService
    {
        private readonly ShoppingCartDbContext db;

        public OrderLineService(ShoppingCartDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Create(OrderLine orderLine)
        {
            try
            {
                db.Add(orderLine);
                Commit();
            }
            catch(OrderLineNotFoundException)
            {
                throw new OrderLineNotFoundException();
            }
        }

        public OrderLine Delete(int id)
        {
            var orderline = GetOrderLineById(id);

            if(orderline != null)
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
    }
}

using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Repository.RespositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Repository.Respositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<OrderLine> orderItemRepository;
        private readonly ShoppingCartDbContext context;

        public UnitOfWork(DbContext dbContext)
        {
            context = (ShoppingCartDbContext)dbContext;
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public GenericRepository<OrderLine> OrderItemRepository
        {
            get
            {
                if (this.orderItemRepository == null)
                {
                    this.orderItemRepository = new GenericRepository<OrderLine>(context);
                }
                return orderItemRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ShoppingCartDbContext DbContext
        {
            get { return context; }
        }
    }
}

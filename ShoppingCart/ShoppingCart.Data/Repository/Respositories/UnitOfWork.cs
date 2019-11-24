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
        public ShoppingCartDbContext shoppingCartDbContext { get; }
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<OrderLine> orderItemRepository;

        public UnitOfWork(DbContext dbContext)
        {
            shoppingCartDbContext = (ShoppingCartDbContext)dbContext;
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(shoppingCartDbContext);
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
                    this.orderRepository = new GenericRepository<Order>(shoppingCartDbContext);
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
                    this.productRepository = new GenericRepository<Product>(shoppingCartDbContext);
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
                    this.orderItemRepository = new GenericRepository<OrderLine>(shoppingCartDbContext);
                }
                return orderItemRepository;
            }
        }

        public void Save()
        {
            shoppingCartDbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    shoppingCartDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

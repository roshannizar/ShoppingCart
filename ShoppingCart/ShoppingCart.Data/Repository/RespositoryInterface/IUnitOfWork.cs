using ShoppingCart.Data.Context;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Repository.Respositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Repository.RespositoryInterface
{
    public interface IUnitOfWork
    {
        ShoppingCartDbContext shoppingCartDbContext { get; }

        GenericRepository<Customer> CustomerRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<OrderLine> OrderItemRepository { get; }
        void Save();

    }
}

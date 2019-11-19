using ShoppingCart.Core.Exceptions;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ShoppingCartDbContext db;

        public CustomerService(ShoppingCartDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Create(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
            }
            catch(CustomerNotFoundException)
            {
                throw new CustomerNotFoundException();
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                var query = from c in db.Customers
                            select c;
                return query;
            }
            catch(CustomerNotFoundException)
            {
                throw new CustomerNotFoundException();
            }
        }
    }
}

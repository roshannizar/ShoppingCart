using AutoMapper;
using ShoppingCart.Core.BusinessObjectModels;
using ShoppingCart.Core.Exceptions;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ShoppingCartDbContext db;
        private readonly IMapper mapper;

        public CustomerService(ShoppingCartDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Create(CustomerBO customerBO)
        {
            try
            {
                var customer = mapper.Map<Customer>(customerBO);
                db.Customers.Add(customer);
            }
            catch(CustomerNotFoundException)
            {
                throw new CustomerNotFoundException();
            }
        }

        public IEnumerable<CustomerBO> GetCustomers()
        {
            try
            {
                var query = from c in db.Customers
                            select c;
                return mapper.Map<IEnumerable<CustomerBO>>(query);
            }
            catch(CustomerNotFoundException)
            {
                throw new CustomerNotFoundException();
            }
        }
    }
}

using ShoppingCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        void Create(Customer customer);
        int Commit();
    }
}

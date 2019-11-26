using ShoppingCart.Core.BusinessObjectModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface ICustomerService
    {
        IEnumerable<CustomerBO> GetCustomers();
        void Create(CustomerBO customer);
    }
}

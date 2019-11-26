using AutoMapper;
using ShoppingCart.Core.BusinessObjectModels;
using ShoppingCart.Core.Exceptions;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Repository.RespositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(CustomerBO customerBO)
        {
            try
            {
                var customer = mapper.Map<Customer>(customerBO);
                unitOfWork.CustomerRepository.Create(customer);
                unitOfWork.Save();
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
                var query = unitOfWork.CustomerRepository.Get();
                return mapper.Map<IEnumerable<CustomerBO>>(query);
            }
            catch(CustomerNotFoundException)
            {
                throw new CustomerNotFoundException();
            }
        }
    }
}

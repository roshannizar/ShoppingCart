using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Web.ViewModels;

namespace ShoppingCart.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService,IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var CustomersBO = customerService.GetCustomers();
            var Customers = mapper.Map<IEnumerable<CustomerViewModel>>(CustomersBO);
            return View(Customers);
        }
    }
}
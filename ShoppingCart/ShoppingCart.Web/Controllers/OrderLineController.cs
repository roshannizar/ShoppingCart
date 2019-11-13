using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Entity;

namespace ShoppingCart.Web.Controllers
{
    public class OrderLineController : Controller
    {
        private readonly IOrderLineService orderLineService;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public IEnumerable<Product> Products { get; set; }

        public OrderLineController(IOrderLineService orderLineService,IProductService productService,ICustomerService customerService)
        {
            this.orderLineService = orderLineService;
            this.productService = productService;
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            //Loading products to drop down
            ViewBag.ProductList = productService.GetProducts().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            //Loading customers to drop down
            ViewBag.CustomerList = customerService.GetCustomers().Select(c => new SelectListItem
            {
                Text = c.FirstName + " "+ c.LastName,
                Value = c.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            return View();
        }
    }
}
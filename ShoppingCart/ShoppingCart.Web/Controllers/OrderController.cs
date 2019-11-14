using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Entity;
using ShoppingCart.Web.ViewModels;

namespace ShoppingCart.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IOrderLineService orderLineService;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public OrderController(IOrderService orderService,IOrderLineService orderLineService,IProductService productService,ICustomerService customerService)
        {
            this.orderService = orderService;
            this.orderLineService = orderLineService;
            this.productService = productService;
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            var Orders = orderService.GetOrders();
            return View(Orders);
        }

        public IActionResult OrderItems()
        {
            //Loading product to drop down
            ViewBag.ProductList = productService.GetProducts().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            //Loading customers to drop down
            ViewBag.CustomerList = customerService.GetCustomers().Select(c => new SelectListItem
            {
                Text = c.FirstName + " " + c.LastName,
                Value = c.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody]OrderPlacementViewModel orderPlacementViewModel)
        {
            try
            {
                var order = new Order
                {
                    CustomerId = orderPlacementViewModel.CustomerId,
                    Date = orderPlacementViewModel.Date,
                    Status = StatusType.Pending
                };

                var orderId = orderService.Create(order);


                for (int i= 0;i < orderPlacementViewModel.OrderItems.Count;i++)
                {
                    var orderline = new OrderLine()
                    {
                        ProductId = orderPlacementViewModel.OrderItems[i].ProductId,
                        Quantity = orderPlacementViewModel.OrderItems[i].Quantity,
                        UnitPrice = orderPlacementViewModel.OrderItems[i].UnitPrice,
                        OrderId = orderId
                    };

                    orderLineService.Create(orderline);

                    //var quantityInStock = productService.GetProduct(orderitems.Id).Quantity;
                    //var remainingStock = quantityInStock - orderitems.Quantity;

                    //var product = new Product
                    //{
                    //    Id = orderitems.Id,
                    //    Quantity = remainingStock
                    //};

                    //var updatedProduct = productService.Update(product);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return View("Index");
        }
    }
}
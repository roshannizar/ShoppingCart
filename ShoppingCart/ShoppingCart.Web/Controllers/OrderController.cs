using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
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
        public IActionResult CreateOrder([FromBody]OrderPlacementViewModel orderPlacementViewModel)
        {
            try
            {
                var order = new Order
                {
                    CustomerId = orderPlacementViewModel.CustomerId,
                    Date = orderPlacementViewModel.Date,
                    Status = StatusType.Pending
                };

                //Create Order
                var orderId = orderService.Create(order);

                //Create Orderline
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

                    //Update the quantity of the given product

                    //var tempProduct = productService.GetProduct(orderPlacementViewModel.OrderItems[i].ProductId);
                    //var remainingstock = tempProduct.Quantity - orderPlacementViewModel.OrderItems[i].Quantity;

                    //var product = new Product
                    //{
                    //    Id = tempProduct.Id,
                    //    Name = tempProduct.Name,
                    //    Description = tempProduct.Description,
                    //    UnitPrice = tempProduct.UnitPrice,
                    //    Quantity = remainingstock
                    //};

                    //productService.Update(product);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult OrderDetail(int id)
        {
            ViewBag.OrderStatus = orderService.GetOrder(id).Status;
            var model = orderLineService.GetOrderLine(id);

            if(model == null)
            {
                return NotFound();
            } 
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult OrderEdit(int id)
        {
            var model = orderLineService.GetOrderLineById(id);

            if(model == null)
            {
                return NotFound();
            } 
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult OrderEdit(OrderItemsViewModel orderItemsViewModel)
        {
            if(ModelState.IsValid)
            {
                var orderLine = new OrderLine
                {
                    Id = orderItemsViewModel.Id,
                    OrderId = orderItemsViewModel.OrderId,
                    ProductId = orderItemsViewModel.ProductId,
                    Quantity = orderItemsViewModel.Quantity,
                    UnitPrice = orderItemsViewModel.UnitPrice
                };

                orderLineService.Update(orderLine);

                return RedirectToAction("OrderDetails", new { id = orderItemsViewModel.OrderId });
            } 
            else
            {
                return View("OrderEdit");
            }
        }

        [HttpPost]
        public IActionResult OrderDelete(int id, FormCollection form)
        {
            try
            {
                orderService.Delete(id);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        [HttpPost]
        public IActionResult OrderLineDelete(int id, FormCollection form)
        {
            try
            {
                orderLineService.Delete(id);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Core.BusinessObjectModels;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Models;
using ShoppingCart.Web.ViewModels;

namespace ShoppingCart.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public OrderController(IOrderService orderService, IProductService productService,
            ICustomerService customerService,IMapper mapper)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var OrdersBO = orderService.GetOrders();
            var Orders = mapper.Map<IEnumerable<OrderViewModel>>(OrdersBO);
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
                var order = mapper.Map<OrderBO>(orderPlacementViewModel);
               //Create Order
                orderService.CreateOrder(order);
               
                TempData["Message"] = "Order has been added successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error Occured while creating an Order! "+ex;
                throw new Exception();
            }
        }

        [HttpGet]
        public IActionResult OrderDetail(int id)
        {
            try
            {
                //Loads the orders
                var ordersBO = orderService.GetOrderById(id);
                ViewBag.Order = mapper.Map<IEnumerable<OrderViewModel>>(ordersBO);
                //Load the status
                var StatusBO = orderService.GetSingleOrderById(id).Status;
                ViewBag.Status = mapper.Map<StatusTypeViewModel>(StatusBO);

                if (ViewBag.Status != null)
                {
                    var models = orderService.GetOrderLineByOrderId(id);

                    if (models == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        var model = mapper.Map<IEnumerable<OrderItemsViewModel>>(models);
                        return View(model);
                    }
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                TempData["Message"] = "No Order found! "+ex;
                throw new Exception();
            }
        }

        [HttpPost]
        public IActionResult OrderDelete(int id)
        {
            try
            {
                orderService.DeleteOrder(id);
                TempData["Message"] = "You have deleted the order Ref No: "+id+" successfully!";
                return RedirectToAction("Order","Index");
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Error occured while deleting the order "+id+"! "+ex;
                throw new Exception();
            }
        }

        [HttpPost]
        public IActionResult OrderEdit([FromBody]List<OrderItemsViewModel> orderItemsViewModel)
        {
            try
            {
                if (!ModelState.IsValid)                                   
                   return View("OrderEdit");                   
                
                if (!(orderItemsViewModel.Count > 0))
                    return RedirectToAction("Index");

                var order = mapper.Map<List<OrderLineBO>>(orderItemsViewModel);
                orderService.UpdateOrder(order);

                TempData["Message"] = "Save changes made for order Ref No: " +
                    orderItemsViewModel[0].OrderId + " successfully!";
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                TempData["Message"] = "Error occured while updating the order! "+ex;
                throw new Exception();
            }
        }
    }
}
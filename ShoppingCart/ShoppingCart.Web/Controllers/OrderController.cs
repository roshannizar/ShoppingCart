﻿using System;
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
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public OrderController(IOrderService orderService, IProductService productService,ICustomerService customerService)
        {
            this.orderService = orderService;
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
                var orderId = orderService.CreateOrder(order);

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

                    //Creating Order Line
                    orderService.CreateOrderLine(orderline);

                    //Update the quantity of the given product
                    UpdateProductQuantity(orderPlacementViewModel,null,i);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private void UpdateProductQuantity(OrderPlacementViewModel orderPlacementViewModel, OrderItemsViewModel orderItemsViewModel,int i)
        {
            if (orderPlacementViewModel is null)
            {
                var tempProduct = productService.GetProduct(orderItemsViewModel.ProductId);
                var remainingstock = tempProduct.Quantity - orderItemsViewModel.Quantity;

                tempProduct.Quantity = remainingstock;

                productService.Update(tempProduct);
            }
            else
            {
                var tempProduct = productService.GetProduct(orderPlacementViewModel.OrderItems[i].ProductId);
                var remainingstock = tempProduct.Quantity - orderPlacementViewModel.OrderItems[i].Quantity;

                tempProduct.Quantity = remainingstock;

                productService.Update(tempProduct);
            }

        }

        [HttpGet]
        public IActionResult OrderDetail(int id)
        {
            //Loads the orders
            ViewBag.Order = orderService.GetOrder(id);
            //Load the status
            ViewBag.Status = orderService.GetOrderObject(id).Status;
            var model = orderService.GetOrderLine(id);

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
        public IActionResult OrderDelete(int id)
        {
            try
            {
                orderService.DeleteOrder(id);
                TempData["Message"] = "You have deleted the order Ref No: "+id+" successfully!";
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        [HttpPost]
        public IActionResult OrderEdit([FromBody]List<OrderItemsViewModel> orderItemsViewModel)
        {
            if(ModelState.IsValid)
            {
                //Checks the order item count
                if (orderItemsViewModel.Count > 0)
                {
                    for (int i = 0; i < orderItemsViewModel.Count; i++)
                    {
                        var orderLineTemp = orderService.GetOrderLineById(orderItemsViewModel[i].Id);

                        if(orderItemsViewModel[i].Quantity != orderLineTemp.Quantity)
                        {
                            orderLineTemp.Quantity = orderItemsViewModel[i].Quantity;
                            orderService.UpdateOrderLine(orderLineTemp);

                        }
                    }
                    TempData["Message"] = "Save changes made for order Ref No: " + 
                        orderItemsViewModel[0].OrderId + " successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            } 
            else
            {
                return View("OrderEdit");
            }
        }
    }
}
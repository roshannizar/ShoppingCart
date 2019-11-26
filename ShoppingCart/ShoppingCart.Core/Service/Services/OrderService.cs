using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Core.BusinessObjectModels;
using ShoppingCart.Core.Exceptions;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Repository.RespositoryInterface;

namespace ShoppingCart.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ProductService productService;

        public OrderService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            productService = new ProductService(unitOfWork, mapper);
        }

        public void CreateOrder(OrderBO orderBO)
        {
            try
            {
                foreach(var items in orderBO.OrderItems)
                {
                    productService.Update(items.ProductId, -(items.Quantity));
                }

                var order = mapper.Map<Order>(orderBO);
                //This method will add orderlines as well, since this entity has the orderline list
                unitOfWork.OrderRepository.Create(order);
                unitOfWork.Save();
                
            }
            catch(OrderNotFoundException ex)
            {
                throw ex;
            }
        }

        public void UpdateOrder(List<OrderLineBO> orderLineBOs)
        {
            try
            {
                var order = mapper.Map<List<OrderLine>>(orderLineBOs);

                foreach (var item in order)
                {
                    //Retrieving the orderline as temporary to check the database quantity
                    var tempOrderLineBO = GetOrderLineById(item.Id);

                    //Identifying the difference between the updated orderline and database quantity
                    var tempDifference = tempOrderLineBO.Quantity - item.Quantity;

                    //setting the quantity
                    item.Quantity = item.Quantity;

                    if (tempOrderLineBO.Quantity == 0)
                    {
                        //If the quantity is zero the order item is deleted
                        DeleteOrderLine(tempOrderLineBO);
                    }
                    else
                    {
                        //updates the difference quantity
                        //productService.Update(item.ProductId, tempDifference);

                        //updates the orderline
                        unitOfWork.OrderItemRepository.Update(item);
                        unitOfWork.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOrder(int id)
        {
            try
            {
                var orderBO = GetSingleOrderById(id);

                if (orderBO == null)
                    throw new OrderNotFoundException();

                var order = mapper.Map<Order>(orderBO);
                //Checks the status type
                if (order.Status == StatusType.Confirmed)
                {
                    //product quantity will not be update if the status is confirmed
                    unitOfWork.OrderRepository.Delete(order);
                }
                else
                {
                    //Retrieving the orderLine from the database, so that can get the quantity
                    var orderLineBOTemp = GetOrderLineByOrderId(id);

                    foreach (var temp in orderLineBOTemp)
                    {
                        //updates the quantity
                        //productService.Update(temp.ProductId, temp.Quantity);
                    }

                    unitOfWork.OrderRepository.Delete(order);
                }
                //Records will be saved after checking the status type
                unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOrderLine(OrderLineBO orderLineBO)
        {
            if (orderLineBO == null)
                throw new OrderLineNotFoundException();

            var orderLine = mapper.Map<OrderLine>(orderLineBO);
            unitOfWork.OrderItemRepository.Delete(orderLine);
            unitOfWork.Save();
        }

        public IEnumerable<OrderBO> GetOrders()
        {
            var query = unitOfWork.OrderRepository.Get(includeProperties:"OrderItems,Customers");
            return mapper.Map<IEnumerable<OrderBO>>(query);
        }

        public IEnumerable<OrderBO> GetOrderById(int id)
        {
            var query = unitOfWork.OrderRepository.Get(includeProperties:"Customers")
                .Where(o =>o.Id == id)
                .Select(obo => new OrderBO
                {
                    Id =obo.Id,
                    CustomerId = obo.CustomerId,
                    Customers = mapper.Map<CustomerBO>(obo.Customers),
                    Date = obo.Date,
                    Status = mapper.Map<StatusTypeBO>(obo.Status),
                    OrderItems = mapper.Map<List<OrderLineBO>>(obo.OrderItems)
                }).ToList();

            return mapper.Map<IEnumerable<OrderBO>>(query);
        }

        public IEnumerable<OrderLineBO> GetOrderLineByOrderId(int id)
        {
            var query = unitOfWork.OrderItemRepository.Get(includeProperties: "Orders,Products")
                 .Where(o => o.OrderId == id)
                 .Select(obo => new OrderLineBO
                 {
                     Id = obo.Id,
                     OrderId = obo.OrderId,
                     Orders = mapper.Map<OrderBO>(obo.Orders),
                     ProductId = obo.ProductId,
                     Products = mapper.Map<ProductBO>(obo.Products),
                     Quantity = obo.Quantity,
                     UnitPrice = obo.UnitPrice
                 }).ToList(); 

            return mapper.Map<IEnumerable<OrderLineBO>>(query);
        }

        public OrderBO GetSingleOrderById(int id)
        {
            var query = unitOfWork.OrderRepository.GetByID(id);
            return mapper.Map<OrderBO>(query);
        }

        public OrderLineBO GetOrderLineById(int id)
        {
            var query = unitOfWork.OrderItemRepository.GetByID(id);
            return mapper.Map<OrderLineBO>(query);
        }
    }
}

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
                foreach(var item in orderBO.OrderItems)
                {
                    //Updating the product
                    productService.Update(item.ProductId, -(item.Quantity));
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

        public void UpdateOrder(OrderBO orderBOs)
        {
            try
            {

                foreach (var item in orderBOs.OrderItems)
                {
                    //Retrieving the orderline as temporary to check the database quantity
                    var tempOrderLine = unitOfWork.OrderItemRepository.GetByID(item.Id);

                    //Identifying the difference between the updated orderline and database quantity
                    var tempDifference = tempOrderLine.Quantity - item.Quantity;

                    //setting the quantity
                    tempOrderLine.Quantity = item.Quantity;

                    if (item.Quantity == 0)
                    {
                        //If the quantity is zero the order item is deleted
                        DeleteOrderLine(tempOrderLine);
                    }
                    else
                    {

                        //updates the orderline
                        var order = mapper.Map<OrderLine>(tempOrderLine);
                        unitOfWork.OrderItemRepository.Update(order);
                        unitOfWork.Save();
                    }

                    //updates the difference quantity
                    productService.Update(item.ProductId, tempDifference);
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
                var orderBO = unitOfWork.OrderRepository.GetByID(id);

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
                    var orderLineBOTemp = GetOrderById(id).OrderItems;

                    foreach (var temp in orderLineBOTemp)
                    {
                        //updates the quantity
                        productService.Update(temp.ProductId, temp.Quantity);
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

        private void DeleteOrderLine(OrderLine orderLine)
        {
            if (orderLine == null)
                throw new OrderLineNotFoundException();
            unitOfWork.OrderItemRepository.Delete(orderLine);
            unitOfWork.Save();
        }

        public IEnumerable<OrderBO> GetOrders()
        {
            var query = unitOfWork.OrderRepository.Get(includeProperties:"OrderItems,Customers");
            return mapper.Map<IEnumerable<OrderBO>>(query);
        }

        public OrderBO GetOrderById(int id)
        {
            var query = unitOfWork.OrderRepository.Get(includeProperties: "Customers,OrderItems").First(o => o.Id == id);

            return mapper.Map<OrderBO>(query);
        }

    }
}

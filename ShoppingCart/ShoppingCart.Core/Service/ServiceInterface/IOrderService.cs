using ShoppingCart.Core.BusinessObjectModels;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IOrderService
    {
        IEnumerable<OrderBO> GetOrders();
        OrderBO GetOrderById(int id);
        void CreateOrder(OrderBO order);
        void UpdateOrder(List<OrderLineBO> orderLineBOs);
        void DeleteOrder(int id);
    }
}

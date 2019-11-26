using ShoppingCart.Core.BusinessObjectModels;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IOrderService
    {
        IEnumerable<OrderBO> GetOrders();
        IEnumerable<OrderBO> GetOrderById(int id);
        IEnumerable<OrderLineBO> GetOrderLineByOrderId(int id);
        OrderBO GetSingleOrderById(int id);
        void CreateOrder(OrderBO order);
        void UpdateOrder(List<OrderLineBO> orderLineBOs);
        void DeleteOrder(int id);
    }
}

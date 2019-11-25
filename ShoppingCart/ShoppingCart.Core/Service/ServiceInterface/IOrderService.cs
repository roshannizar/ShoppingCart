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
        OrderLineBO GetOrderLineById(int id);
        void CreateOrder(OrderBO order);
        void UpdateOrder(OrderBO order);
        void DeleteOrderLine(OrderLineBO orderLine);
        void DeleteOrder(int id);
    }
}

using ShoppingCart.Data.Models;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrderById(int id);
        IEnumerable<OrderLine> GetOrderLineByOrderId(int id);
        Order GetSingleOrderById(int id);
        OrderLine GetOrderLineById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrderLine(OrderLine orderLine);
        void DeleteOrder(int id);
    }
}

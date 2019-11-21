using ShoppingCart.Data.Entity;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrder(int id);
        IEnumerable<OrderLine> GetOrderLines();
        IEnumerable<OrderLine> GetOrderLine(int id);
        Order GetOrderObject(int id);
        OrderLine GetOrderLineById(int id);

        int GetLastOrderId();
        void CreateOrder(Order order);
        void UpdateOrder(OrderLine orderLine);
        OrderLine DeleteOrderLine(int id);
        void DeleteOrder(int id);
        int Commit();
    }
}

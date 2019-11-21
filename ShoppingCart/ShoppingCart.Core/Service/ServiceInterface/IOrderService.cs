using ShoppingCart.Data.Entity;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrderById(int id);
        IEnumerable<OrderLine> GetOrderLine(int id);
        Order GetSingleOrderById(int id);
        OrderLine GetSingleOrderLineById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(OrderLine orderLine);
        void DeleteOrderLine(int id);
        void DeleteOrder(int id);
        int Commit();
    }
}

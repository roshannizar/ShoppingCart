using ShoppingCart.Data.Entity;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrder(int id);
        Order GetOrderObject(int id);
        int Create(Order order);
        void Delete(int id);
        int GetLastOrderId();
        int Commit();
    }
}

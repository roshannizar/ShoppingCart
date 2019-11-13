using ShoppingCart.Data.Entity;
using System.Collections.Generic;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IOrderLineService
    {
        IEnumerable<OrderLine> GetOrderLines();
        IEnumerable<OrderLine> GetOrderLine(int id);
        OrderLine GetOrderLineById(int id);
        void Create(OrderLine orderLine);
        OrderLine Delete(int id);
        int Commit();
    }
}

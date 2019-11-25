using ShoppingCart.Core.BusinessObjectModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IProductService
    {
        IEnumerable<ProductBO> GetProducts();
        ProductBO GetProduct(int id);
        IEnumerable<ProductBO> GetProductByName(string name);
        void Create(ProductBO product);
        void Update(ProductBO product);
        int Commit();
    }
}

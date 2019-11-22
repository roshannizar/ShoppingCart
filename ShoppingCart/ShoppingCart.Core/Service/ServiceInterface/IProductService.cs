﻿using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.ServiceInterface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        IEnumerable<Product> GetProductByName(string name);
        void Create(Product product);
        void Update(Product product);
        int Commit();
    }
}

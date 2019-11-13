using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCart.Data.Context;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Entity;
using ShoppingCart.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoppingCartDbContext db;

        public ProductService(ShoppingCartDbContext db)
        {
            this.db = db;
        }

        public void Create(Product product)
        {
            try
            {
                db.Add(product);
            }
            catch(ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                var query = from r in db.Products
                            orderby r.Name
                            select r;

                return query;
            }
            catch(ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                var query = db.Products.Find(id);
                return query;
            }
            catch(ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            try
            {
                var query = from r in db.Products
                            where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                            orderby r.Name
                            select r;

                return query;
            }
            catch(ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public Product Update(Product product)
        {
            try
            {
                var entity = db.Products.Attach(product);
                entity.State = EntityState.Modified;

                return product;
            }
            catch(ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCart.Data.Context;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Data.Models;
using ShoppingCart.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ShoppingCart.Core.BusinessObjectModels;

namespace ShoppingCart.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoppingCartDbContext db;
        private readonly IMapper mapper;

        public ProductService(ShoppingCartDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void Create(ProductBO productBO)
        {
            try
            {
                var product = mapper.Map<Product>(productBO);
                db.Add(product);
            }
            catch (ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public IEnumerable<ProductBO> GetProducts()
        {
            try
            {
                var query = from r in db.Products
                            orderby r.Name
                            select r;

                return mapper.Map<IEnumerable<ProductBO>>(query.ToList());
            }
            catch (ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public ProductBO GetProduct(int id)
        {
            try
            {
                var query = db.Products.Find(id);
                return mapper.Map<ProductBO>(query);
            }
            catch (ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public IEnumerable<ProductBO> GetProductByName(string name)
        {
            try
            {
                var query = from r in db.Products
                            where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                            orderby r.Name
                            select r;

                return mapper.Map<IEnumerable<ProductBO>>(query);
            }
            catch (ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Update(ProductBO productBO)
        {
            try
            {
                var product = mapper.Map<Product>(productBO);
                var entry = db.Entry(product);
                entry.State = EntityState.Modified;
                Commit();
            }
            catch (ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

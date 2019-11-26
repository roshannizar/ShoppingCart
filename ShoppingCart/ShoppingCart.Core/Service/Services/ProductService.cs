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
using ShoppingCart.Data.Repository.RespositoryInterface;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(ProductBO productBO)
        {
            try
            {
                var product = mapper.Map<Product>(productBO);
                unitOfWork.ProductRepository.Create(product);
                unitOfWork.Save();
            }
            catch (ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public IEnumerable<ProductBO> GetProducts()
        {
            try
            {
                var query = (unitOfWork.ProductRepository.Get());

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
                var query = unitOfWork.ProductRepository.GetByID(id);
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
                var productList = (unitOfWork.ProductRepository.Get()
                  .Where(p => p.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                     .Select(p => new ProductBO
                     {
                         Id = p.Id,
                         Name = p.Name
                     }));

                if (productList.Count() == 0)
                {
                    productList = productList.Concat(new ProductBO[] { new ProductBO() { Id = -1, Name = "No Products Available!" } });
                    return productList;
                }
                else
                {
                    return productList;
                }
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
        
        public void Update(int productId, int quantity)
        {
            try
            {
                var productBO = unitOfWork.ProductRepository.GetByID(productId);

                if (productBO != null)
                {
                    productBO.Quantity = productBO.Quantity + quantity;
                }
                else
                {
                    throw new ProductNotFoundException();
                }

                var product = mapper.Map<Product>(productBO);
                unitOfWork.ProductRepository.Update(product);
                unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

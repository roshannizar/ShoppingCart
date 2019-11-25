using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Core.ServiceInterface;
using ShoppingCart.Web.ViewModels;

namespace ShoppingCart.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var ProductsBO = productService.GetProducts();
            var Products = mapper.Map<IEnumerable<ProductViewModel>>(ProductsBO);
            return View(Products);
        }


        public JsonResult GetProductById(int id)
        {
            var productBO = productService.GetProduct(id);
            var product = mapper.Map<ProductViewModel>(productBO);
            return Json(product);
        }
    }
}
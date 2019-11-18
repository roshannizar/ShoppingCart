﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Core.ServiceInterface;

namespace ShoppingCart.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var Products = productService.GetProducts();
            return View(Products);
        }


        public JsonResult GetProductById(int id)
        {
            var product = productService.GetProduct(id);
            return Json(product);
        }
    }
}
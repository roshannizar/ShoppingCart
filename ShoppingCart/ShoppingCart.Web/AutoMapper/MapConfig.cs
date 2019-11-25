using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Core.BusinessObjectModels;
using ShoppingCart.Data.Models;
using ShoppingCart.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Web.AutoMapper
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<Order, OrderBO>().ReverseMap();
            CreateMap<OrderLine, OrderLineBO>().ReverseMap();
            CreateMap<OrderViewModel, OrderBO>().ReverseMap();
            CreateMap<OrderPlacementViewModel, OrderBO>().ReverseMap();
            CreateMap<OrderLineBO,OrderItemsViewModel>().ReverseMap();
            CreateMap<ProductBO, Product>().ReverseMap();
            CreateMap<ProductViewModel, ProductBO>().ReverseMap();
            CreateMap<CustomerBO, Customer>().ReverseMap();
            CreateMap<CustomerBO, CustomerViewModel>().ReverseMap();
            CreateMap<ProductListModel, SelectListItem>().ReverseMap();
            CreateMap<CustomerListModel, SelectListItem>().ReverseMap();
        }
        
    }
}

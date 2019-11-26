using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Core.BusinessObjectModels;
using ShoppingCart.Data.Models;
using ShoppingCart.Web.ViewModels;

namespace ShoppingCart.Web.AutoMapper
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<Order, OrderLine>().ReverseMap();

            CreateMap<OrderBO, Order>().ReverseMap();
            CreateMap<OrderLineBO, OrderLine>().ReverseMap();
            CreateMap<OrderBO, OrderLineBO>().ReverseMap();

            CreateMap<OrderViewModel, OrderBO>().ReverseMap();
            CreateMap<OrderPlacementViewModel, OrderBO>().ReverseMap();
            CreateMap<ProductViewModel, ProductBO>().ReverseMap();

            CreateMap<OrderLineBO,OrderItemsViewModel>().ReverseMap();
            CreateMap<CustomerBO, CustomerViewModel>().ReverseMap();

            CreateMap<ProductBO, Product>().ReverseMap();
            CreateMap<CustomerBO, Customer>().ReverseMap();

            CreateMap<ProductListModel, SelectListItem>().ReverseMap();
            CreateMap<CustomerListModel, SelectListItem>().ReverseMap();
        }
        
    }
}

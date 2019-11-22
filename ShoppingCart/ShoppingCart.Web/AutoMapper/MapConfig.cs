using AutoMapper;
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
            //CreateMap<OrderBO, Order>().ReverseMap();
            //CreateMap<OrderLineBO,OrderLine>().ReverseMap();
            CreateMap<Order,OrderPlacementViewModel>().ReverseMap();
            CreateMap<OrderLine,OrderItemsViewModel>().ReverseMap();
        }
        
    }
}

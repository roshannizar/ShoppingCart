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
            CreateMap<Order, OrderBO>().ReverseMap();
            CreateMap<OrderLine,OrderLineBO>().ReverseMap();
            CreateMap<OrderBO, OrderPlacementViewModel>().ReverseMap();
            CreateMap<OrderLineBO, OrderItemsViewModel>().ReverseMap();
        }
        
    }
}
